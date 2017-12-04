using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL1
{
    class Gramatica
    {
        // Enumeración para los tipos de gramática que pueden tener
        // las producciones 
        public enum TIPO_GRAMATICA
        {
            TYPE0 = 1,
            SIN_RESTRICCIONES = 1,
            TYPE1 = 2,
            DEPENDIENTE_DE_CONTEXTO = 2,
            TYPE2 = 3,
            LIBRE_DE_CONTEXTO = 3,
            TYPE3 = 4,
            REGULAR = 4,
            INVALID = 5
        };

        public enum GRAM_ERROR
        {
            NO_ERROR = 0,
            ERROR = 1,
            EPSILON_ERROR = 2,
            EMPTY_GRAM = 3

        };

        private TIPO_GRAMATICA _type;               // Variable para guardar el tipo de gramática.
        private List<char> _terminales;
        private List<char> _no_terminales;
        private String _prod_inicial;
        private String _gram_formal;
        private List<String> _input_lines;
        private List<Produccion> _producciones;
        private List<Produccion> _primero;
        private List<Produccion> _siguiente;
        private bool is_inicial;
        private List<List<String>> _tabla_analisis;

        public Gramatica()
        {
            _terminales = new List<char>();
            _no_terminales = new List<char>();
            _input_lines = new List<string>();
            _prod_inicial = "";
            _producciones = new List<Produccion>();
            _primero = new List<Produccion>();
            _siguiente = new List<Produccion>();
            _type = TIPO_GRAMATICA.REGULAR;
        }

        /// <summary>
        /// Devuelve el tipo de gramática siempre que la propiedad IsValid sea true.
        /// </summary>
        public TIPO_GRAMATICA Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Devuelve la lista de No terminales.
        /// </summary>
        public List<char> NoTerminales
        {
            get { return _no_terminales; }
        }

        /// <summary>
        /// Devuelve la lista de terminales.
        /// </summary>
        public List<char> Terminales
        {
            get { return _terminales; }
        }
        /// <summary>
        /// Devuelve la producción inicial.
        /// </summary>
        public String ProduccionInicial
        {
            get { return _prod_inicial; }
        }

        /// <summary>
        /// Devuelve una cadena con el formato de la gramática formal.
        /// </summary>
        public String GramaticaFormal
        {
            get { return _gram_formal; }
        }

        /// <summary>
        /// Obtiene la lista de producciones de la gramática
        /// </summary>
        public List<Produccion> Producciones
        {
            get { return _producciones; }
        }

        public List<Produccion> Primero
        {
            get { return _primero; }
        }

        public List<Produccion> Siguiente
        {
            get { return _siguiente; }
        }

        public List<List<String>> TablaAnalisis
        {
            get { return _tabla_analisis; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineas"></param>
        /// <returns></returns>
        public GRAM_ERROR AnalizaLineas(String[] lineas)
        {
            Produccion p;
            TIPO_GRAMATICA t_actual;
            // Limpia la lista de producciones.
            _producciones.Clear();
            _prod_inicial = "";


            for (int i = 0; i < lineas.Length; i++)
            {
                p = new Produccion(lineas[i]);

                // Si no hay errores en la producción
                if (p.Error == Produccion.PROD_ERROR.NO_ERROR)
                {
                    // Agrega la linea de texto a las lineas.
                    //_input_lines.Add(lineas[i]);

                    // Si la produccion es válida...
                    if (p.IsValid)
                    {
                        _producciones.Add(p);       // Agrega la producción a la lista.
                        t_actual = _check_type(p);  // Obtiene el tipo de gramática de la producción.

                        // Si la gramática es sin restricciones.
                        if (t_actual == TIPO_GRAMATICA.SIN_RESTRICCIONES)
                        {
                            _type = t_actual;   // Se establece el tipo de la gramática.
                            //break;              // Termina el análisis
                        }
                        else // Si no, si la gramatica de la producción actual de menor jerarquia que la anterior, guarda la nueva jerarquia.
                        if (t_actual < _type)
                        {
                            _type = t_actual;
                        }
                    }
                }
                else
                {
                    return GRAM_ERROR.ERROR;
                }
            }


            if (_producciones.Count != 0)
                _generate_formal_gram();
            else
                return GRAM_ERROR.EMPTY_GRAM;

            return GRAM_ERROR.NO_ERROR;
        }

        private void _generate_formal_gram()
        {
            String n_t, s_t;
            for (int i = 0; i < _producciones[0].LeftItems.Count; i++)
                _prod_inicial += _producciones[0].LeftItems[i];


            // Recorre todas las producciones en busca de terminales y no terminales
            for (int i = 0; i < _producciones.Count; i++)
            {

                // Busca terminales y no terminales del lado izquierdo
                for (int j = 0; j < _producciones[i].LeftItems.Count; j++)
                {
                    // Si el item izquierdo es no terminal...
                    if (Produccion.IsNoTerminal(_producciones[i].LeftItems[j][0]))
                    {
                        // Si no existe el item en la lista de no termilaes lo agerga
                        if (!_no_terminales.Contains(_producciones[i].LeftItems[j][0]))
                            _no_terminales.Add(_producciones[i].LeftItems[j][0]);

                    }
                    else// Si no, si el item es terminal
                    {
                        // Si no existe el item en la lista de terminales lo agerga.
                        if (!_terminales.Contains(_producciones[i].LeftItems[j][0]))
                            _terminales.Add(_producciones[i].LeftItems[j][0]);
                    }
                }

                // Busca terminales y no terminales del lado derecho
                for (int j = 0; j < _producciones[i].RightItems.Count; j++)
                {
                    // Si el item derecho es no terminal...
                    for (int k = 0; k < _producciones[i].RightItems[j].Length; k++)
                    {

                        if (Produccion.IsNoTerminal(_producciones[i].RightItems[j][k]))
                        {
                            // Si no existe el item en la lista de no termilaes lo agerga
                            if (!_no_terminales.Contains(_producciones[i].RightItems[j][k]))
                                _no_terminales.Add(_producciones[i].RightItems[j][k]);
                        }
                        else// Si no, si el item es terminal
                        {
                            if (_producciones[i].RightItems[j][k] == '\'' && k > 0 && Produccion.IsNoTerminal(_producciones[i].RightItems[j][k - 1]))
                                break;
                            // Si no existe el item en la lista de terminales lo agerga.
                            if (!_terminales.Contains(_producciones[i].RightItems[j][k]))
                                _terminales.Add(_producciones[i].RightItems[j][k]);
                        }
                    }
                }
            }

            // Formatea los terminales y no terminales para generar la gramática formal
            n_t = "";
            for (int i = 0; i < _no_terminales.Count; i++)
            {
                n_t += _no_terminales[i];
                if (i < _no_terminales.Count - 1)
                    n_t += ", ";
            }

            s_t = "";
            for (int i = 0; i < _terminales.Count; i++)
            {
                s_t += _terminales[i];
                if (i < _terminales.Count - 1)
                    s_t += ", ";
            }

            _gram_formal = "G = ( { " + n_t + " }, { " + s_t + " }, " + _prod_inicial + " )";
        }

        /// <summary>
        /// Determina el tipo de una producción.
        /// </summary>
        /// <param name="prod">Produccion a checar</param>
        private TIPO_GRAMATICA _check_type(Produccion prod)
        {
            TIPO_GRAMATICA t = TIPO_GRAMATICA.INVALID;

            // Si es tipo 3...
            if (_is_type_3(prod))
                return TIPO_GRAMATICA.REGULAR;
            else // Si no, si es tipo 2...
            if (_is_type_2(prod))
                return TIPO_GRAMATICA.LIBRE_DE_CONTEXTO;
            else // Si no, si es tipo 1...
            if (_is_type_1(prod))
                return TIPO_GRAMATICA.DEPENDIENTE_DE_CONTEXTO;
            else // Si no, si es tipo 0...
            if (_is_type_0(prod))
                return TIPO_GRAMATICA.SIN_RESTRICCIONES;

            return t;
        }


        /// <summary>
        /// Determina si la gramatica es de tipo 3 (Regular).
        /// </summary>
        /// <param name="prod">Produccion a checar</param>
        /// <returns>True si la producción es gramática regular, de lo contrario false</returns>
        private Boolean _is_type_3(Produccion prod)
        {
            if (prod.LeftItems.Count == 1 && Produccion.IsNoTerminal(prod.LeftItems[0][0]))
            {
                if (Produccion.IsTerminal(prod.RightItems[0][0]))
                {
                    if (prod.RightItems.Count == 2)
                    {
                        if (Produccion.IsNoTerminal(prod.RightItems[1][0]))
                            return true;
                        else
                            return false;
                    }

                    if (prod.RightItems.Count >= 2)
                        return false;
                    else
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determina si la gramatica es de tipo 2 (Libre de Contexto).
        /// </summary>
        /// <param name="prod">Produccion a checar</param>
        /// <returns>True si la producción es gramática libre de contexto, de lo contrario false</returns>
        private Boolean _is_type_2(Produccion prod)
        {
            if (prod.LeftItems.Count == 1 && Produccion.IsNoTerminal(prod.LeftItems[0][0]))
                return true;

            return false;
        }

        /// <summary>
        /// Determina si la gramatica es de tipo 1 (Dependiente de Contexto).
        /// </summary>
        /// <param name="prod">Produccion a checar</param>
        /// <returns>True si la producción es gramática dependiente de contexto, de lo contrario false</returns>
        private Boolean _is_type_1(Produccion prod)
        {
            // Si el lado izquierdo y el lado derecho son diferentes de epsilon
            if (prod.LeftItems[0][0] != prod.Epsilon && prod.RightItems[0][0] != prod.Epsilon && prod.LeftItems.Count <= prod.RightItems.Count)
            {
                // checar que los elementos de cada lado de la producción coincidan con el formato xAy -> xjy
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determina si la gramatica es de tipo 0 (Sin Restricciones).
        /// </summary>
        /// <param name="prod">Produccion a checar</param>
        /// <returns>True si la producción es gramática sin restricciones, de lo contrario false</returns>
        private Boolean _is_type_0(Produccion prod)
        {
            // La única restricción es que la parte izquierda sea diferente de epsilon.
            if (prod.LeftItems[0][0] != prod.Epsilon)
                return true;

            return false;
        }

        public void elimina_recursividad()
        {
            string str_prod = "";
            Produccion prod;
            List<Produccion> nueva = new List<Produccion>();

            for (int i = 0; i < _producciones.Count; i++)
            {
                str_prod = _producciones[i].Value;
                for (int j = 0; j < i; j++)
                {
                    str_prod = remplaza_produccion(_producciones[i], _producciones[j]);
                    _producciones[i].Value = str_prod;
                }

                prod = new Produccion(str_prod);

                Boolean first = true;
                foreach (Produccion p in elimina_recursividad_directa(prod))
                {
                    nueva.Add(p);
                    if (first)
                    {
                        first = false;
                       _producciones[i].Value = p.Value;
                    }
                }
            }
            _producciones.Clear();
            _producciones = nueva;
        }
        private string remplaza_produccion(Produccion source, Produccion to_replace)
        {
            string prod=source.LeftItems[0] + " -> ";

            for (int i = 0; i < source.RightItems.Count; i++)
            {
                if (source.RightItems[i][0] == to_replace.LeftItems[0][0])
                {
                    source.RightItems[i] = source.RightItems[i].Remove(0, 1);

                    for (int j = 0; j < to_replace.RightItems.Count; j++)
                    {
                        prod += to_replace.RightItems[j] + source.RightItems[i];
                        if (j < to_replace.RightItems.Count)
                            prod += "|";
                    }
                }
                else
                {
                    prod += source.RightItems[i] + "|";
                }
            }

            if (prod[prod.Length - 1] == '|')
                prod = prod.Remove(prod.Length - 1, 1);

            return prod;
        }
        public List<Produccion> elimina_recursividad_directa(Produccion p)
        {
            List<Produccion> nueva = new List<Produccion>();
            String str_prod1 = p.LeftItemsStr + " -> ";
            String str_prod2 = p.LeftItemsStr + "' -> ";
            Boolean tiene_recursividad = false;


            for (int i = 0; i < p.RightItems.Count; i++)
            {
                if(p.RightItems[i][0] == p.LeftItems[0][0])
                {
                    tiene_recursividad = true;
                    str_prod2 += p.RightItems[i].Remove(0, 1) + p.LeftItemsStr + "'";

                    if ( i < p.RightItems.Count -1)
                        str_prod2 += "|";

                }
                else
                {
                    if(p.RightItems[i] != "\u03B5")
                        str_prod1 += p.RightItems[i] + p.LeftItemsStr + "'";
                    else
                        str_prod1 += p.LeftItemsStr + "'";

                    if (i < p.RightItems.Count - 1)
                        str_prod1 += "|";

                }
            }

            // Si tiene recursividad
            if (tiene_recursividad)
            {
                // Crea la producción 1 nueva.
                if (str_prod1[str_prod1.Length - 1] == '|')
                    str_prod1 = str_prod1.Remove(str_prod1.Length - 1, 1);

                nueva.Add(new Produccion(str_prod1));

                // Crea la producción 2 nueva con un epsilon al final.
                if(str_prod2[str_prod2.Length-1] == '|')
                {
                    str_prod2 += "\u03B5";
                }
                else
                    str_prod2 += "|\u03B5";

                nueva.Add(new Produccion(str_prod2));
            }
            else // Si no tiene recursividad devuelve la misma producción.
                nueva.Add(p);

            return nueva;
        }

        public void factoriza()
        {
            List<Produccion> nueva = new List<Produccion>();

            foreach (Produccion p in _producciones)
            {
                foreach (Produccion pn in factoriza_produccion(p))
                {
                 
                    nueva.Add(pn);
                }
            }

            _producciones.Clear();
            _producciones = nueva;
        }
        public List<Produccion> factoriza_produccion(Produccion p)
        {
            List<Produccion> nueva = new List<Produccion>();
            String str_prod1 = p.LeftItemsStr + " -> ";
            String str_prod2 = p.LeftItemsStr + "' -> ";
            String prefijo;
            String prefijo_max = "";
            int coincidencias_max = 0;
            int coincidencias;

            for (int i = 0; i < p.RightItems.Count; i++)
            {
                
                prefijo = "";
                for (int k = 0; k < p.RightItems[i].Length; k++)
                {
                    prefijo += "" + p.RightItems[i][k];
                    coincidencias = 0;
                    for (int j = 0; j < p.RightItems.Count; j++)
                    {
                        // implementar otra función de busqueda del prefijo
                        if (p.RightItems[j].Contains(prefijo))
                            coincidencias++;  
                        //*************************************************
                    }

                    if (coincidencias > 1 && prefijo.Length >= prefijo_max.Length )

                    {
                        if (prefijo.Length == prefijo_max.Length)
                        {
                            if (coincidencias > coincidencias_max)
                            {
                                prefijo_max = prefijo;
                                coincidencias_max = coincidencias;
                            }
                        }
                        else
                        {
                            prefijo_max = prefijo;
                            coincidencias_max = coincidencias;
                        }
                    }
                }
                
            }

            // Si tiene un factor
            if (prefijo_max.Length > 0)
            {
                String str = "";
                str_prod1 += prefijo_max + p.LeftItems[0] + "'|";

                for (int i = 0; i < p.RightItems.Count; i++)
                {
                    // implementar otra función de busqueda del prefijo
                    if (p.RightItems[i].Contains(prefijo_max))
                    {
                    //*************************************************
                        str = p.RightItems[i].Remove(0, prefijo_max.Length);


                        if (str == "")
                            str = "\u03B5";

                        str_prod2 += str;

                        if (i < p.RightItems.Count-1)
                            str_prod2 += "|";

                        
                    }
                    else
                    {
                        str_prod1 += p.RightItems[i];
                        if (i < p.RightItems.Count-1)
                            str_prod1 += "|";
                    }
                    
                }

                if (str_prod1[str_prod1.Length - 1] == '|')
                    str_prod1 = str_prod1.Remove(str_prod1.Length - 1, 1);

                if (str_prod2[str_prod2.Length - 1] == '|')
                    str_prod2 = str_prod2.Remove(str_prod2.Length - 1, 1);

                nueva.Add(new Produccion(str_prod1));
                nueva.Add(new Produccion(str_prod2));
            }
            else // Si no tiene factorización devuelve la misma producción.
                nueva.Add(p);

            return nueva;
        }

        public void calcula_primero()
        {

            _primero = new List<Produccion>();

            for (int i = _producciones.Count - 1; i >= 0; i--)
            {
                _primero.Insert(0, calcula_primero_produccion(_producciones[i]));
                //_primero.Add(calcula_primero_produccion(_producciones[i]));
                
            }
        }
        public Produccion calcula_primero_produccion(Produccion prod)
        {
           
            string prod_str = "";
            prod_str = prod.LeftItems[0] + " -> ";

            foreach (string item in prod.RightItems)
            {
                string first = dame_primero_de_item(item);

                // si el primer elemento del item derecho es terminal, se agrega a la producción
                if (Produccion.IsTerminal(first[0]))
                {
                    prod_str += "" + item[0] + "|";
                }
                else // si no busca el primero del no terminal en la lista de primeros.
                {
                    // recorre la lista de los primeros
                    foreach(Produccion p in _primero)
                    {
                        // Si existe el primero obtenido en la lista, asigna sus elementos a el
                        // primero de este.
                        if(p.LeftItems[0] == first)
                        {
                            foreach(string it in p.RightItems)
                                prod_str += it + "|";

                            break;
                        }
                    }  
                }
            }

            return new Produccion(prod_str);
        }

        public void calcula_siguiente()
        {
            _siguiente = new List<Produccion>();
            is_inicial = true;
            foreach (Produccion p in _producciones)
            {
                _siguiente.Add(calcula_siguiente_produccion(p));
            }
            _terminales.Add('$');

        }
        public Produccion calcula_siguiente_produccion(Produccion prod)
        {
            string prod_str = "";
            string left_str = prod.LeftItems[0] + " -> ";

            
            // Obtiene todas las producciones que contienen al no terminal izquierdo
            // de la produccion a calcular                     
            foreach (Produccion p_aux in dame_producciones_no_terminal(prod))
            {
                // Recorre todos los elementos derechos de las producciones
                // para aplicar las reglas
                foreach(String it in p_aux.RightItems)
                {
                    // si la produccion contiene al no terminal a evaluar...
                    string item = it.Replace(prod.LeftItems[0] + "'", "");

                    if (item.Contains(prod.LeftItems[0]))
                        if (!item.Contains(prod.LeftItems[0] + "'"))
                        {
                            item = it;
                        // checa la regla que se le aplica para obtener el sigueinte
                        switch (checa_regla_siguiente(item, prod.LeftItems[0]))
                        {
                            case 1:
                                    int index = item.IndexOf(prod.LeftItems[0]);

                                    if (index < item.Length - 1)
                                        index ++;

                                    while (index < item.Length && item[index] == '\'')
                                    index++;

                                    char sig = item[index];

                                    // Si beta es un terminal lo agrega
                                    if (Produccion.IsTerminal(sig))
                                    {
                                        if (!prod_str.Contains(sig))
                                            prod_str += "" + sig + "|";
                                    }
                                    else
                                    {
                                        // si beta es un no terminal obtiene el no terminal
                                        string nt = "" + item[index++];
                                        while (index <item.Length && item[index++] == '\'')
                                            nt += "'";

                                            // agrega los primeros del terminal obtenido a los
                                            // siguientes de la produccion actual
                                            foreach (String s in get_primeros(nt))
                                            {
                                                // si el elemento no está en la lista y es difete de epsilon...
                                                if (s !="\u03B5" && !prod_str.Contains(s))
                                                    prod_str += "" + s + "|";
                                            }

                                            if (get_primeros(nt).Contains("\u03B5"))
                                            {
                                                if (p_aux.LeftItems[0] != prod.LeftItems[0])
                                                    foreach (String s in get_siguientes(p_aux.LeftItems[0]))
                                                    {
                                                        if (!prod_str.Contains(s))
                                                            prod_str += "" + s + "|";
                                                    }
                                            }
                                    }

                                break;
                            case 2:
                                if(p_aux.LeftItems[0] != prod.LeftItems[0])
                                foreach(String s in get_siguientes(p_aux.LeftItems[0]))
                                {
                                      if(!prod_str.Contains(s))
                                        prod_str += "" + s + "|";
                                }
                                break;
                            case 3:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (is_inicial)
            {
                is_inicial = false;
                prod_str += "$";
            }

            return new Produccion(left_str+prod_str);
        }

        public void genera_tabla_analisis()
        {
            _tabla_analisis = new List<List<string>>();
            _terminales.Remove('\u03B5');

            for (int i = 0; i < _primero.Count; i++)
            {
                List<string> _row = new List<string>();

                for (int j = 0; j < _terminales.Count; j++)
                    _row.Add("");

                for (int j = 0; j < _primero[i].RightItems.Count; j++)
                {

                    if (_primero[i].RightItems[j] == "\u03B5")
                    {
                        foreach (string s in get_siguientes(_primero[i].LeftItems[0]))
                        {
                            int k;
                            for (k = 0; k < _terminales.Count && _terminales[k] != s[0]; k++) ;

                            if (k < _terminales.Count)
                            {
                                if (_row[k] == "")
                                    _row[k] = "\u03B5";
                                else
                                    _row[k] += " | " + "\u03B5";
                            }

                        }
                        
                    }
                    else
                    {

                        string prod = get_prod_tabla(_producciones[i], _primero[i].RightItems[j]);
                        int k;
                        for (k = 0; k < _terminales.Count && _terminales[k] != _primero[i].RightItems[j][0]; k++) ;

                        if (k < _terminales.Count)
                        {
                            if (_row[k] == "")
                                _row[k] = prod;
                            else
                                _row[k] += " | " + prod;
                        }
                    }
                    
                }

                _tabla_analisis.Add(_row);
            }
            

        }

        private string get_prod_tabla(Produccion p, string c)
        {
            string prod="";
            for (int i = 0; i < p.RightItems.Count; i++)
            {
                // si el primero es un terminal, devulve la producción que genera ese terminal
                if (Produccion.IsTerminal(p.RightItems[i][0]))
                {
                    if (p.RightItems[i][0] == c[0])
                    {
                        prod =  p.RightItems[i];
                        break;
                    }
                }
                else
                {
                    string nt = "" + p.RightItems[i][0];
                    int index = 1;
                    if (p.RightItems[i].Length > 1)
                    {
                        while (index < p.RightItems[i].Length && p.RightItems[i][index++] == '\'')
                            nt += "'";
                    }

                    prod = get_prod_tabla(get_produccion(nt), c);
                    if(prod != "")
                        prod = p.RightItems[i];
                }
               
            }

            return prod;
        }

        private Produccion get_produccion(string no_terminal)
        {
            foreach (Produccion p in _producciones)
                if (p.LeftItems[0] == no_terminal)
                    return p;

            return new Produccion("");
        }
        private string dame_primero_de_item(string item)
        {
            string primero = "" + item[0];

            if (Produccion.IsNoTerminal(item[0]))
            {
                if (item.Length > 1)
                {
                    for (int i = 1; i < item.Length; i++)
                    {
                        if (item[i] == '\'')
                            primero += "'";
                        else
                            break;
                    }
                }
            }

            return primero;
        }
        private List<String> get_primeros(String p)
        {
            foreach (Produccion prod in _primero)
            {
                if (prod.LeftItems[0] == p)
                    return prod.RightItems;
            }

            return new List<string>();
        }
        private List<String> get_siguientes(String p)
        {
            foreach(Produccion prod in _siguiente)
            {
                if (prod.LeftItems[0] == p)
                    return prod.RightItems;
            }

            return new List<string>();
        }
        private int checa_regla_siguiente(String item, String no_terminal)
        {
            int index = item.IndexOf(no_terminal);

            
            if (index < item.Length - 1 && (item[index+1]=='\'' || Produccion.IsNoTerminal(item[index+1])))
                index++;

            while (index < item.Length && item[index] == '\'')
                index++;
            

            // si tiene parte derecha
            if (index < item.Length-1 )
                return 1;
            else
                return 2;

            return 0;
        }
        public List<Produccion> dame_producciones_no_terminal(Produccion prod)
        {
            List<Produccion> p = new List<Produccion>();

            foreach (Produccion aux_p in _producciones)
            {
                foreach(String s_aux in aux_p.RightItems)
                {
                    string s = s_aux.Replace(prod.LeftItems[0] + "'", "");
                    if (s.Contains(prod.LeftItems[0]))
                        if (!s.Contains(prod.LeftItems[0] + "'"))
                        {
                            p.Add(aux_p);
                            break;
                        }
                }
            }

            return p;
        }
        public Boolean tiene_prefijo(string pref, string cad)
        {

            return false;
        }

    }
}
