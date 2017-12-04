namespace LL1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_gramatica = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_recursiva = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_factorizada = new System.Windows.Forms.RichTextBox();
            this.btn_analizar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simboloÉpsilonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.símboloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_primero = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tb_siguiente = new System.Windows.Forms.RichTextBox();
            this.dg_tabla_analisis = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_msg = new System.Windows.Forms.TextBox();
            this.btn_evaluar = new System.Windows.Forms.Button();
            this.tb_entrada = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tb_pila_ev = new System.Windows.Forms.RichTextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tb_pila_in = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_tabla_analisis)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_gramatica
            // 
            this.tb_gramatica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_gramatica.Location = new System.Drawing.Point(6, 19);
            this.tb_gramatica.Name = "tb_gramatica";
            this.tb_gramatica.Size = new System.Drawing.Size(198, 188);
            this.tb_gramatica.TabIndex = 0;
            this.tb_gramatica.Text = "";
            this.tb_gramatica.WordWrap = false;
            this.tb_gramatica.TabStopChanged += new System.EventHandler(this.tb_gramatica_TabStopChanged);
            this.tb_gramatica.TextChanged += new System.EventHandler(this.tb_gramatica_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_gramatica);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 213);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editor de Gramática";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_recursiva);
            this.groupBox2.Location = new System.Drawing.Point(336, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 212);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gramática sin Recursividad";
            // 
            // tb_recursiva
            // 
            this.tb_recursiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_recursiva.Location = new System.Drawing.Point(6, 19);
            this.tb_recursiva.Name = "tb_recursiva";
            this.tb_recursiva.ReadOnly = true;
            this.tb_recursiva.Size = new System.Drawing.Size(172, 187);
            this.tb_recursiva.TabIndex = 0;
            this.tb_recursiva.Text = "";
            this.tb_recursiva.WordWrap = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_factorizada);
            this.groupBox3.Location = new System.Drawing.Point(526, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 212);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gramática Factorizada";
            // 
            // tb_factorizada
            // 
            this.tb_factorizada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_factorizada.Location = new System.Drawing.Point(6, 19);
            this.tb_factorizada.Name = "tb_factorizada";
            this.tb_factorizada.ReadOnly = true;
            this.tb_factorizada.Size = new System.Drawing.Size(172, 187);
            this.tb_factorizada.TabIndex = 0;
            this.tb_factorizada.Text = "";
            this.tb_factorizada.WordWrap = false;
            // 
            // btn_analizar
            // 
            this.btn_analizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_analizar.Image = global::LL1.Properties.Resources.btn;
            this.btn_analizar.Location = new System.Drawing.Point(237, 87);
            this.btn_analizar.Name = "btn_analizar";
            this.btn_analizar.Size = new System.Drawing.Size(85, 87);
            this.btn_analizar.TabIndex = 4;
            this.btn_analizar.Text = "Analizar";
            this.btn_analizar.UseVisualStyleBackColor = true;
            this.btn_analizar.Click += new System.EventHandler(this.btn_analizar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.insertarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // insertarToolStripMenuItem
            // 
            this.insertarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simboloÉpsilonToolStripMenuItem,
            this.símboloToolStripMenuItem});
            this.insertarToolStripMenuItem.Name = "insertarToolStripMenuItem";
            this.insertarToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.insertarToolStripMenuItem.Text = "Insertar";
            // 
            // simboloÉpsilonToolStripMenuItem
            // 
            this.simboloÉpsilonToolStripMenuItem.Name = "simboloÉpsilonToolStripMenuItem";
            this.simboloÉpsilonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.simboloÉpsilonToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.simboloÉpsilonToolStripMenuItem.Text = "Simbolo épsilon";
            this.simboloÉpsilonToolStripMenuItem.Click += new System.EventHandler(this.simboloEpsilonToolStripMenuItem_Click);
            // 
            // símboloToolStripMenuItem
            // 
            this.símboloToolStripMenuItem.Name = "símboloToolStripMenuItem";
            this.símboloToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.símboloToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.símboloToolStripMenuItem.Text = "Símbolo ->";
            this.símboloToolStripMenuItem.Click += new System.EventHandler(this.símboloToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel1.Text = "Listo!";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tb_primero);
            this.groupBox4.Location = new System.Drawing.Point(716, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(184, 212);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Primero";
            // 
            // tb_primero
            // 
            this.tb_primero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_primero.Location = new System.Drawing.Point(6, 19);
            this.tb_primero.Name = "tb_primero";
            this.tb_primero.ReadOnly = true;
            this.tb_primero.Size = new System.Drawing.Size(172, 187);
            this.tb_primero.TabIndex = 0;
            this.tb_primero.Text = "";
            this.tb_primero.WordWrap = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tb_siguiente);
            this.groupBox5.Location = new System.Drawing.Point(906, 32);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(184, 212);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Siguiente";
            // 
            // tb_siguiente
            // 
            this.tb_siguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_siguiente.Location = new System.Drawing.Point(6, 19);
            this.tb_siguiente.Name = "tb_siguiente";
            this.tb_siguiente.ReadOnly = true;
            this.tb_siguiente.Size = new System.Drawing.Size(172, 187);
            this.tb_siguiente.TabIndex = 0;
            this.tb_siguiente.Text = "";
            this.tb_siguiente.WordWrap = false;
            // 
            // dg_tabla_analisis
            // 
            this.dg_tabla_analisis.AllowUserToAddRows = false;
            this.dg_tabla_analisis.AllowUserToDeleteRows = false;
            this.dg_tabla_analisis.AllowUserToResizeColumns = false;
            this.dg_tabla_analisis.AllowUserToResizeRows = false;
            this.dg_tabla_analisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_tabla_analisis.Location = new System.Drawing.Point(6, 13);
            this.dg_tabla_analisis.MultiSelect = false;
            this.dg_tabla_analisis.Name = "dg_tabla_analisis";
            this.dg_tabla_analisis.ReadOnly = true;
            this.dg_tabla_analisis.RowHeadersVisible = false;
            this.dg_tabla_analisis.Size = new System.Drawing.Size(742, 177);
            this.dg_tabla_analisis.TabIndex = 9;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.tb_msg);
            this.groupBox6.Controls.Add(this.btn_evaluar);
            this.groupBox6.Controls.Add(this.tb_entrada);
            this.groupBox6.Location = new System.Drawing.Point(18, 250);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(312, 196);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Evaluar Cadena";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mensajes";
            // 
            // tb_msg
            // 
            this.tb_msg.Location = new System.Drawing.Point(6, 91);
            this.tb_msg.Multiline = true;
            this.tb_msg.Name = "tb_msg";
            this.tb_msg.ReadOnly = true;
            this.tb_msg.Size = new System.Drawing.Size(298, 99);
            this.tb_msg.TabIndex = 2;
            // 
            // btn_evaluar
            // 
            this.btn_evaluar.Location = new System.Drawing.Point(240, 33);
            this.btn_evaluar.Name = "btn_evaluar";
            this.btn_evaluar.Size = new System.Drawing.Size(64, 23);
            this.btn_evaluar.TabIndex = 1;
            this.btn_evaluar.Text = "Evaluar";
            this.btn_evaluar.UseVisualStyleBackColor = true;
            this.btn_evaluar.Click += new System.EventHandler(this.btn_evaluar_Click);
            // 
            // tb_entrada
            // 
            this.tb_entrada.Location = new System.Drawing.Point(6, 33);
            this.tb_entrada.Name = "tb_entrada";
            this.tb_entrada.Size = new System.Drawing.Size(228, 20);
            this.tb_entrada.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dg_tabla_analisis);
            this.groupBox7.Location = new System.Drawing.Point(336, 250);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(754, 196);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tabla de Análisis Sintáctico LL1";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tb_pila_ev);
            this.groupBox8.Location = new System.Drawing.Point(1096, 32);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(184, 212);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Pila de evaluación";
            // 
            // tb_pila_ev
            // 
            this.tb_pila_ev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pila_ev.Location = new System.Drawing.Point(6, 19);
            this.tb_pila_ev.Name = "tb_pila_ev";
            this.tb_pila_ev.ReadOnly = true;
            this.tb_pila_ev.Size = new System.Drawing.Size(172, 187);
            this.tb_pila_ev.TabIndex = 0;
            this.tb_pila_ev.Text = "";
            this.tb_pila_ev.WordWrap = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tb_pila_in);
            this.groupBox9.Location = new System.Drawing.Point(1096, 250);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(184, 212);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Pila de la entrada";
            // 
            // tb_pila_in
            // 
            this.tb_pila_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pila_in.Location = new System.Drawing.Point(6, 19);
            this.tb_pila_in.Name = "tb_pila_in";
            this.tb_pila_in.ReadOnly = true;
            this.tb_pila_in.Size = new System.Drawing.Size(172, 187);
            this.tb_pila_in.TabIndex = 0;
            this.tb_pila_in.Text = "";
            this.tb_pila_in.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 471);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_analizar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Analizador Sintáctico LL1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_tabla_analisis)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tb_gramatica;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox tb_recursiva;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox tb_factorizada;
        private System.Windows.Forms.Button btn_analizar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simboloÉpsilonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem símboloToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox tb_primero;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox tb_siguiente;
        private System.Windows.Forms.DataGridView dg_tabla_analisis;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_evaluar;
        private System.Windows.Forms.TextBox tb_entrada;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_msg;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RichTextBox tb_pila_ev;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RichTextBox tb_pila_in;
    }
}

