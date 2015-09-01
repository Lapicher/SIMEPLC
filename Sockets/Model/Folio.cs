using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sockets.Model
{
    public class Folio
    {
        private List<Medida> medidas=null;
        private string folio;
        public string Codigo2D
        {
            get
            {
                return folio;
            }
            set
            {
                folio = value;
            }
        }
        public List<Medida> Medidas
        {
            get
            {
                return medidas;
            }
            set
            {
                medidas = value;
            }
        }
    }
}
