using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sockets.Model
{
    public class Medida
    {
        private int idregistro;
        private string valor;
        public int IdRegistro
        {
            get
            {
                return idregistro;
            }
            set
            {
                idregistro = value;
            }
        }
        public string Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }
    }
}
