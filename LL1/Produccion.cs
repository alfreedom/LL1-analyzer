using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL1
{
    class Produccion
    {

        public enum PROD_ERROR
        {
            NO_ERROR = 0,           // Sin errores.
            INVALID_CHARACTER = 1,   // Error si un caracter no está en la lista de "terminales" ni en la lista de "no terminales".
            INVALID_PRODUCTION = 2, // Error si una producción tiene mas de dos simbolos "->"
        };


        // Cadena con los caracteres Terminales.
        private static String _terminales = "abcdefghijklmnñopqrstuvwxyz0123456789<>()[],.:;_+-*/!¡¿?$%&{}=|'\\\u03B5";
        // Cadena con los caracteres No Terminales.
        private static String _no_terminales = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";

        private const char _epsilon = '\u03B5';    // Constante para el caracter EPSILON.
        private PROD_ERROR _error;                  // Variable para manejar los errores en la cadena.
        private String _prod_str;              // Variable para guardar la cadena a analizar.
        private List<string> _left_items;             // Lista para guardar los elementos izquierdos de la producción.
        private List<string> _right_items;            // Lista para guardar los elementos derechos de la producción.
        private String _right_items_str;
        private String _left_items_str;
        private Boolean _is_valid_prod;       // Variable para guardar si es una producción válida.


        /// <summary>
        /// Constructor de la clase Produccion.
        /// </summary>
        /// <param name="str_prod">Cadena que represeta una producción.</param>
        public Produccion(string str_prod)
        {
            _prod_str = str_prod;
            _right_items = new List<string>();
            _left_items = new List<string>();
            _is_valid_prod = true;
            _error = PROD_ERROR.NO_ERROR;

            _analize_production();
        }

        public char Epsilon
        {
            get { return _epsilon; }
        }
        /// <summary>
        /// Devuelve el error de la producción.
        /// </summary>
        public PROD_ERROR Error
        {
            get { return _error; }
        }

        /// <summary>
        /// Indica si la producción es una producción valida.
        /// </summary>
        public Boolean IsValid
        {
            get { return _is_valid_prod; }
        }

        /// <summary>
        /// Lee o escribe la cadena que representa la producción.
        /// </summary>
        public String Value
        {
            get { return _prod_str; }
            set
            {
                _prod_str = value;
                _right_items.Clear();
                _left_items.Clear();
                _right_items_str = "";
                _left_items_str = "";
                _is_valid_prod = true;
                _error = PROD_ERROR.NO_ERROR;

                _analize_production();
            }
        }

        /// <summary>
        /// Devuelve los elementos izquierdos de una producción siempre que la propiedad IsValid sea true.
        /// </summary>
        public List<string> LeftItems
        {
            get { return _left_items; }
        }

        public String LeftItemsStr
        {
            get { return _left_items_str; }
        }

        public String RightItemsStr
        {
            get { return _right_items_str; }
        }
        /// <summary>
        /// Devuelve los elementos derechos de una producción siempre que la propiedad IsValid sea true.
        /// </summary>
        public List<string> RightItems
        {
            get { return _right_items; }
        }

        /// <summary>
        /// Analiza la cadena que representa la producción.
        /// Separa la parte izquieda y derecha de la producción, y de ser válida
        /// determina su tipo.
        /// </summary>
        private void _analize_production()
        {
            Boolean is_arrow = false;
            Boolean has_epsilon = false;
            String[] str_aux;
            string item = "";

            // Elimina espacios.
            str_aux = _prod_str.Split(' ');
            _prod_str = "";
            foreach (string l in str_aux)
                _prod_str += l;

            // Elimina tabuladores.
            str_aux = _prod_str.Split('\t');
            _prod_str = "";
            foreach (string l in str_aux)
                _prod_str += l;

            // Si la cadena de producción está vacía...
            if (_prod_str == "")
            {
                _is_valid_prod = false;     // Es una producción sin error, pero no válida.
                return;
            }
            else // Si no...
            {
                // Recorre todos los caracteres de la cadena de producción.
                for (int i = 0; i < _prod_str.Length; i++)
                {
                    // Si encuentra un simbolo flecha '->'...
                    if (_prod_str[i] == '-' && i < _prod_str.Length - 1 && _prod_str[i + 1] == '>')
                    {
                        // Si no tiene flecha...
                        if (!is_arrow)
                        {
                            if(item != "")
                                _left_items.Add(item);

                            item = "";
                            is_arrow = true;        // Levanta la bandera de flecha.
                            has_epsilon = false;    // Baja la bandera de epsilon.
                            i++;                    // Avanza al siguiente caracter despues de '>'.
                        }
                        else // Si ya tiene flecha (encontró otra flecha)
                        {
                            _is_valid_prod = false;                 // La producción es inválida.
                            _error = PROD_ERROR.INVALID_PRODUCTION; // Error de producción inválida.
                            break;                                  // Termina el ciclo.
                        }
                    }
                    else // Si no es simbolo flecha '->'...
                    {

                        // Si el caracter es epsilon y no ha tenido empsilon..
                        if (_prod_str[i] == _epsilon && !has_epsilon)
                        {
                            has_epsilon = true;     // Bandera tiene epsilon a true.

                            // Si no tiene flecha...
                            if (!is_arrow)
                            {
                                //_left_items.Clear();            // Limpia la lista de elementos izquierdos.
                                _left_items.Add("" + _prod_str[i]);  // Inserta epsilon en el lado izquierdo.
                                _left_items_str = "" + _prod_str[i];// Agrega el epsilon a la cadena
                            }
                            else { // Si ya tiene flecha        
                               // _right_items.Clear();           // Limpia la lista de elementos derechos.
                                _right_items.Add("" + _prod_str[i]); // Inserta epsilon en el lado derecho.
                                _right_items_str = "" + _prod_str[i];// Agrega el epsilon a la cadena
                                break;                          // Termina el ciclo.

                            }
                        }
                        else // Si no.... Si el caracter es un un Terminal o un No Terminal...
                        if (IsTerminal(_prod_str[i]) || IsNoTerminal(_prod_str[i]))
                        {
                            // Si no tiene flecha, guarda el caracter del lado izquierdo de la producción
                            // y si tiene flecha lo guarda del lado derecho.
                            if (!has_epsilon)
                            {
                                
                                if (!is_arrow)
                                {
                                    if (_prod_str[i] == '|')
                                    {
                                        if (item != "")
                                            _left_items.Add(item);
                                        item = "";
                                    }
                                    else
                                        item += "" + _prod_str[i];

                                    _left_items_str += _prod_str[i];
                                }
                                else {
                                    if (_prod_str[i] == '|')
                                    {
                                        if (item != "")
                                            _right_items.Add(item);
                                        item = "";
                                    }
                                    else
                                        item += "" + _prod_str[i];

                                    _right_items_str += _prod_str[i];

                                }
                            }
                        }
                        else // Si no, marca un error de caracter invalido.
                        {
                            _is_valid_prod = false;                 // La producción es inválida.
                            _error = PROD_ERROR.INVALID_CHARACTER;  // Error de caracter inválido.
                            break;                                  // Termina el ciclo.
                        }
                    }
                }
            }

            
            if (item != "")
                _right_items.Add(item);

            // Si no hay componentes izquierdos o derechos en la producción... error!.
            if (!is_arrow || _left_items.Count == 0 || _right_items.Count == 0)
                _error = PROD_ERROR.INVALID_PRODUCTION;

        }

        /// <summary>
        /// Determina si un caracter está en la lista de Terminales.
        /// </summary>
        /// <param name="c">Caracter a checar.</param>
        /// <returns>true si el caracter es terminal, de lo contrario false</returns>
        public static Boolean IsTerminal(char c)
        {
            return _terminales.Contains(c);
        }

        /// <summary>
        /// Determina si un caracter está en la lista de NO Terminales.
        /// </summary>
        /// <param name="c">Caracter a checar.</param>
        /// <returns>true si el caracter es No Terminal, de lo contrario false</returns>
        public static Boolean IsNoTerminal(char c)
        {
            return _no_terminales.Contains(c);
        }
    }
}
