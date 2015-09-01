using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.Net;

namespace Sockets
{
    
        public delegate void miDelegate(object socket);
        public class Socket : DataSocket
        {
            private string clasi;
            private string acceso;
            private string tipo;
            //private string url;
            private int idreg;

            public int IdRegistro
            {
                get { return idreg; }
                set { idreg = value; }
            }
            public string Clasificacion
            {
                get { return clasi; }
                set { clasi = value; }
            }
            public string Acceso
            {
                get { return acceso; }
                set { acceso = value; }
            }
            public string TipoR
            {
                get { return tipo; }
                set { tipo = value; }
            }

            //replico evento del DataSocket
            public miDelegate EventoSocket;
            public Socket(string u)
            {
                this.AutoConnect = false;
                this.DataUpdated += new DataUpdatedEventHandler(ValorNuevo);
                //url = u;
                this.Url = u;
            }
            //evento de Datasocket.
            private void ValorNuevo(object sender, DataUpdatedEventArgs e)
            {
                if(EventoSocket!=null)
                    this.EventoSocket(this);
            }
        }
    
}
