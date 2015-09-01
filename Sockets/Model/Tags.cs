using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sockets
{
    public class Tags
    {
        private int idregistro;
        private string tag;
        private string tipor;
        private string acceso;
        private string clasificacion;

        public int idRegistro
        {
            set
            {
                idregistro = value;
            }
            get
            {
                return idregistro;
            }
        }

        public string Tag
        {
            set
            {
                tag = value;
            }
            get
            {
                return tag;
            }
        }

        public string TipoR
        {
            set
            {
                tipor = value;
            }
            get
            {
                return tipor;
            }
        }

        public string Acceso
        {
            set
            {
                acceso = value;
            }
            get
            {
                return acceso;
            }
        }

        public string Clasificacion
        {
            set
            {
                clasificacion = value;
            }
            get
            {
                return clasificacion;
            }
        }

    }
}
