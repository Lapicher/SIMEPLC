using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sockets
{
    public class Estacion
    {
        private string nombre;
        private int idesta;
        private string url;
        public string NombreEstacion
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
        public int idEstacion
        {
            set
            {
                idesta = value;
            }
            get
            {
                return idesta;
            }
        }
        public string URL
        {
            set
            {
                url = value;
            }
            get
            {
                return url;
            }
        }
    }
}
