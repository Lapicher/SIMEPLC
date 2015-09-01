using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sockets
{
    public class VariablesPLC
    {
        private String desc;
        private int idreg;
        private string tg;

        public int idregistro
        {
            set
            {
                idreg = value;
            }
            get
            {
                return idreg;
            }
        }

        public string tag
        {
            set
            {
                tg = value;
            }
            get
            {
                return tg;
            }
        }

        public string Descripcion
        {
            set
            {
                desc = value;
            }
            get
            {
                return desc;
            }
        }
    }
}
