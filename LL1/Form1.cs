using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace LL1
{
    public partial class Form1 : Form
    {

        string current_file_name;
        string[] file_text_lines;
        Boolean is_file_open = false;
        Boolean is_file_edited = false;
        Gramatica gram;

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult results;
            SaveFileDialog save_file_dlg = new SaveFileDialog();
            OpenFileDialog open_file_dlg = new OpenFileDialog();

            save_file_dlg.InitialDirectory = Application.StartupPath + "\\gramaticas";
            open_file_dlg.InitialDirectory = Application.StartupPath + "\\gramaticas";

            if (is_file_edited)
            {
                results = MessageBox.Show("No ha guardado el archivo actual\n¿Desea guardar el archvio?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (results == DialogResult.Yes)
                {
                    if (!is_file_open)
                    {
                        if (save_file_dlg.ShowDialog() == DialogResult.OK)
                            current_file_name = save_file_dlg.FileName;
                        else
                            return;
                    }
                    File.WriteAllText(current_file_name, tb_gramatica.Text);
                }
                else if (results == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (open_file_dlg.ShowDialog() == DialogResult.OK)
            {
                current_file_name = open_file_dlg.FileName;
                file_text_lines = File.ReadAllLines(current_file_name);

                tb_recursiva.Text = "";
                tb_factorizada.Text = "";
                tb_gramatica.Text = "";
                tb_primero.Text = "";
                tb_siguiente.Text = "";

                foreach (string l in file_text_lines)
                    tb_gramatica.Text += l + "\r\n";
                this.Text = "Analizador LL1 - " + current_file_name;
                toolStripStatusLabel1.Text = "Archivo abierto :)";
                
                is_file_open = true;
                is_file_edited = false;
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            toolStripProgressBar1.Step = 10;
            if (!is_file_open)
            {
                SaveFileDialog save_file_dlg = new SaveFileDialog();
                save_file_dlg.InitialDirectory = Application.StartupPath + "\\gramaticas";

                if (save_file_dlg.ShowDialog() == DialogResult.OK)
                    current_file_name = save_file_dlg.FileName;
                else
                    return;
            }
          
            File.WriteAllText(current_file_name, tb_gramatica.Text);
            
            this.Text = "Analizador LL1 - " + current_file_name;

            toolStripStatusLabel1.Text = "Archivo guardado :)";
            is_file_edited = false;
            is_file_open = true;
            toolStripProgressBar1.Value = 0;
            
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_file_dlg = new SaveFileDialog();
            save_file_dlg.InitialDirectory = Application.StartupPath + "\\gramaticas";

            if (save_file_dlg.ShowDialog() == DialogResult.OK)
                current_file_name = save_file_dlg.FileName;
            else
                return;

            File.WriteAllText(current_file_name, tb_gramatica.Text);
            this.Text = "Gramaticas - " + current_file_name;
            toolStripStatusLabel1.Text = "Archivo guardado :)";
            is_file_edited = false;
            is_file_open = true;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult results;

            if (is_file_edited)
            {
                results = MessageBox.Show("No ha guardado el archivo actual\n¿Desea salir sin guardar el archivo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (results == DialogResult.No)
                    return;
            }

            this.Close();
        }

        private void btn_analizar_Click(object sender, EventArgs e)
        {
            Gramatica.GRAM_ERROR err_code;

            gram = new Gramatica();
            String[] lines = tb_gramatica.Lines;
            tb_recursiva.Text = "";
            tb_factorizada.Text = "";
            tb_primero.Text = "";
            tb_siguiente.Text = "";

            // Si hay lineas que analizar...
            if (lines.Length != 0)
            {
                // Analiza las lineas de la gramatica y devielve el error.
                err_code = gram.AnalizaLineas(lines);

                // Si no hay errores
                if (err_code == Gramatica.GRAM_ERROR.NO_ERROR)
                {
                    // Si el tipo de gramatica no es regular o libre de contexto muestra error
                    if (gram.Type != Gramatica.TIPO_GRAMATICA.LIBRE_DE_CONTEXTO && gram.Type != Gramatica.TIPO_GRAMATICA.REGULAR)
                    {
                        tb_msg.Text = "Error, la gramática no es libre de contexto";
                        return;
                    }

                    // Elimina la recursividad por la izquierda
                    gram.elimina_recursividad();
                    foreach (Produccion prod in gram.Producciones)
                        tb_recursiva.Text += prod.Value + "\r\n";

                    // Factoriza la gramática
                    gram.factoriza();
                    foreach (Produccion prod in gram.Producciones)
                        tb_factorizada.Text += prod.Value + "\r\n";


                    // Calcula el primero de la gramática
                    gram.calcula_primero();
                    for (int i = 0; i < gram.Primero.Count; i++)
                    {
                        Produccion prod = gram.Primero[i];
                        if(prod.LeftItems[0].Length > 1)
                            tb_primero.Text += "P(" + prod.LeftItems[0] + ")" + " =  { ";
                        else
                            tb_primero.Text += "P(" + prod.LeftItems[0] + ")" + "  =  { ";

                        for (int j = 0; j < prod.RightItems.Count; j++)
                        {
                            tb_primero.Text += prod.RightItems[j];
                            if (j < prod.RightItems.Count - 1)
                                tb_primero.Text += " , ";
                        }
                        tb_primero.Text += " }\r\n";
                    }

                    gram.calcula_siguiente();
                    for (int i = 0; i < gram.Siguiente.Count; i++)
                    {
                        Produccion prod = gram.Siguiente[i];
                        if (prod.LeftItems[0].Length > 1)
                            tb_siguiente.Text += "S(" + prod.LeftItems[0] + ")" + " =  { ";
                        else
                            tb_siguiente.Text += "S(" + prod.LeftItems[0] + ")" + "  =  { ";

                        for (int j = 0; j < prod.RightItems.Count; j++)
                        {
                            tb_siguiente.Text += prod.RightItems[j];
                            if (j < prod.RightItems.Count - 1)
                                tb_siguiente.Text += " , ";
                        }
                        tb_siguiente.Text += " }\r\n";
                    }
                    gram.genera_tabla_analisis();
                    muestra_tabla_analisis(gram);

                    tb_recursiva.Text = tb_recursiva.Text.Replace("|", " | ");
                    tb_recursiva.Text = tb_recursiva.Text.Replace("->", " -> ");
                    tb_factorizada.Text = tb_factorizada.Text.Replace("|", " | ");
                    tb_factorizada.Text = tb_factorizada.Text.Replace("->", " -> ");
            
                }
                else // Si hay errores...
                {
                    // Si el error es de gramatica vacía, muestra error de gramática vacía
                    if (err_code == Gramatica.GRAM_ERROR.EMPTY_GRAM)
                        tb_msg.Text = "Gramática vacia, no hay gramática a evaluar";
                    else // si no es error de gramática vacia, muestra mensaje de error en la gramática.
                        tb_msg.Text = "Error en la gramática.";
                }

            }
            else // Si no hay lineas que analizar, muestra error de gramática vacía.
                tb_msg.Text = "Gramática vacia, no hay gramática a evaluar";

        }

        private void muestra_tabla_analisis(Gramatica g)
        {
            DataTable table = new DataTable();
            table.Columns.Add(" ");
            List<string> row_items;

            foreach (char c in g.Terminales)
                if (c != '\u03B5')
                    table.Columns.Add("" + c);
            
            for (int i = 0; i < g.TablaAnalisis.Count; i++)
            {
                row_items = new List<string>();
                row_items.Add(g.Producciones[i].LeftItems[0]);

                foreach (string item in g.TablaAnalisis[i])
                    row_items.Add(item);

                table.Rows.Add(row_items.ToArray());
            }

            dg_tabla_analisis.DataSource = table;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                dg_tabla_analisis.Columns[i].Width = 80;
                dg_tabla_analisis.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dg_tabla_analisis.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dg_tabla_analisis.Columns[0].Width = 30;
        }

        private void simboloEpsilonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFormats.Format fmt = new DataFormats.Format("e", 0);

            Clipboard.SetText("\u03B5");
            tb_gramatica.Focus();
            tb_gramatica.Select(tb_gramatica.SelectionStart, 0);
            tb_gramatica.Paste(fmt);

            Text = "Gramaticas - " + current_file_name + "**";
            toolStripStatusLabel1.Text = "No guardado!";
            is_file_edited = true;
            
            
        }

        private void símboloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFormats.Format fmt = new DataFormats.Format("p", 0);

            Clipboard.SetText("->");

            tb_gramatica.Focus();
            tb_gramatica.Select(tb_gramatica.SelectionStart, 0);
            tb_gramatica.Paste(fmt);

            Text = "Gramaticas - " + current_file_name + "**";
            toolStripStatusLabel1.Text = "No guardado!";
            is_file_edited = true;
        }

        private void btn_evaluar_Click(object sender, EventArgs e)
        {
            tb_msg.Text = "";
            if (tb_entrada.Text == "")
            {
                tb_msg.Text = "No hay cadena a evaluar.";
                return;
            }
            else
            {
                if (is_file_edited || tb_siguiente.Text=="")
                {
                    btn_analizar_Click(null, null);
                    is_file_edited = false;
                }
                if (gram != null && gram.TablaAnalisis != null)
                {
                    if (evalua_cadena(gram, tb_entrada.Text) == 0)
                    {
                        tb_msg.Text = "Error, la cadena no es válida para la gramática";
                        return;
                    }
                    else
                        tb_msg.Text = "OK! La cadena es aceptada por la gramática!";
                }
            
            }
        }

        private int evalua_cadena(Gramatica g, string entrada)
        {
            Stack<string> pila = new Stack<string>();
            int line_number = 0;
            entrada += "$";
            pila.Push("$");
            pila.Push(g.Producciones[0].LeftItems[0]);
            
            tb_pila_in.Text = "" + line_number + ": " + entrada + "\r\n";
            tb_pila_ev.Text = "" + line_number + ": " + "$" + g.Producciones[0].LeftItems[0] + "\r\n";
            line_number++;
            while (entrada.Length != 0 && pila.Count != 0)
            {
                string tope = pila.Pop();
                // si el elemento de la pila es terminal
                if (Produccion.IsTerminal(tope[0]))
                {
                    // Si el elemento del tope es igual al de la entrada, continua
                    // con el siguiente.
                    if (tope == "$" && tope == "" + entrada[0])
                        return 1;

                    if (tope[0] == entrada[0])
                    {
                        entrada = entrada.Remove(0, 1);
                    }
                    else
                        if(tope!= "\u03B5")
                            return 0;
                }
                else // si el tope es un no terminal
                {
                    string element = busca_tabla_analisis(tope,""+ entrada[0]);
                    if(element != "")
                    {
                        List<string> invertidos = genera_tokens(element);
                        foreach (string s in invertidos)
                        {
                            pila.Push(s);
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }

                // Guarda los datos de la iteración para mostrar la pila de evaluación
                
                string aux = "";
                foreach(string s in pila)
                {
                    aux = aux + s;
                }
                tb_pila_ev.Text += "" + line_number + ": " + aux +"\r\n";
                tb_pila_in.Text += "" + line_number + ": " + entrada + "\r\n";
                line_number++;

            }

            return 0;
            
        
        }
        private List<string> genera_tokens(string input)
        {
            List<string> nueva = new List<string>();
            string tok = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (Produccion.IsNoTerminal(input[i]))
                {
                    tok += input[i];
                    if (i < input.Length - 1 && input[i + 1] == '\'')
                    {
                        tok += "'";
                        i++;
                    }
                    nueva.Insert(0,tok);
                    tok = "";
                } else
                if (Produccion.IsTerminal(input[i]))
                {
                    nueva.Insert(0,"" + input[i]);
                }
            }
            return nueva;
        }
        private string busca_tabla_analisis(string prod, string input)
        {
            int i, j;
            for (i = 0; i < gram.Terminales.Count && gram.Terminales[i] != input[0]; i++) ;

            if(i < gram.Terminales.Count)
            {
                for (j = 0; j < gram.Producciones.Count && gram.Producciones[j].LeftItems[0] != prod; j++) ;

                if(j < gram.Producciones.Count)
                {
                    return gram.TablaAnalisis[j][i];
                }
            }


            return "";
        }

        private void tb_gramatica_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void tb_gramatica_TextChanged(object sender, EventArgs e)
        {
            is_file_edited = true;
        }
    }
}
