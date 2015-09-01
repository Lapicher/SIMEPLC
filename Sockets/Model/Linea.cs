using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sockets
{
    public class Linea
    {
        private string nombre;
        private int idlinea;
        

        public string Nombre_linea
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }
        public int idLinea
        {
            set
            {
                idlinea = value;
            }
            get
            {
                return idlinea;
            }
        }

    }
}
