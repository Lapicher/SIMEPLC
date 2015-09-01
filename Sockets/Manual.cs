using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Net;

namespace Sockets
{
    public partial class Manual : Form
    {
        public String msj, url, valor;
        private Estacion est;
        private List<Socket> sockets;

        private string[] estadosLectorSIME=new string[2]{"Secuencia OK","SEcuencia Incorrecta"};
        private string[] estadosLectorPLC = new string[2] { "Ingresa Campana a Estacion", "Retiene Campana"};
        private string[] estadosMediSIME = new string[4] { "Campana aceptada", "Campana rechazada", "Repite programa", "Pieza no medida" };
        private string[] estadosMediPLC = new string[4] { "Continua flujo", "Expulsarla al contenedor", "Toma mediciones", "Continua flujo" };

        private int[] programa=null;
        private int[] posicion=null;
        private int[] archivos=null;
        private int[] alabeo=null;
        private int[] lvdt=null;
        private int nvecesPrograma = 0;

        public Manual(Estacion estacion, Linea linea)
        {
            est = estacion;
            InitializeComponent();
            
            sockets = CargarTag();
            conectarSockets();

            CargarCondicionesIniciales();
           
            CargarVariables();
        }
        private void CargarCondicionesIniciales()
        {
            foreach (Socket soc in sockets)
            {
                if (soc.Clasificacion == "I")
                {
                    object dato ;
                    soc.Update();
                    switch (soc.TipoR)
                    {
                           
                        case "modelo":
                            
                            dato= soc.Data.Value;
                            label.Text = "" + dato;
                            break;
                        case "modo":
                            dato = soc.Data.Value;
                            label11.Text = "" + dato;
                            break;
                        case "prog":
                            programa = (int[])soc.Data.Value;

                            break;
                        case "pos":
                            posicion = (int[])soc.Data.Value;
                            break;
                        case "file":
                            archivos = (int[])soc.Data.Value;
                            break;
                        case "lvdt":
                            lvdt = (int[])soc.Data.Value;
                            break;
                        case "ntotal":
                            break;
                        case "alabeo":
                            alabeo = (int[])soc.Data.Value;
                            break;
                    }
                }
            }
            if (programa == null)
            {
                lb_programas.Text = "0/0";
                nvecesPrograma=1;
            }
        }
       
        private List<Socket> CargarTag()
        {
            Conexion conexion = new Conexion();
            List<Socket> tags = new List<Socket>();
            int numCampos = 5;
            List<String> resultados = conexion.Consulta("select idregistro,tag,tipor,acceso,clasificacion from registro inner join tiporeg on idregistro=Registro_idregistro where Estacion_idEstacion="+est.idEstacion+" and r_estatus=1 order by clasificacion,idRegistro", numCampos);
            for (int i = 0; i < resultados.Count; i += numCampos)
            {
                Socket tag = new Socket(est.URL);
                tag.IdRegistro = Convert.ToInt32(resultados[i]);
                tag.Tag = resultados[i+1];
                tag.Url += tag.Tag;    
                tag.TipoR = resultados[i + 2];
                tag.Acceso = resultados[i + 3];
                tag.Clasificacion = resultados[i + 4];

                //MessageBox.Show("imprime Url COMPLETA: " + tag.Url);
                
                tags.Add(tag);
            }
            return tags;
        }

        private void escucheDatoNuevo(object sender)
        {
            Socket socket = (Socket)sender;
            // bandera de sime del LECTOR.
            if(socket.TipoR=="S" && socket.Clasificacion=="L")
                if ((int)socket.Data.Value == 1)
                {
                    MessageBox.Show("Dato: " + socket.Data.Value);
                    socket.Data.Value = 0;
                }
            //bandera de sime de MEDICIONES
            if (socket.TipoR == "S" && socket.Clasificacion == "M")
                if ((int)socket.Data.Value == 1)
                {
                    MessageBox.Show("Dato: " + socket.Data.Value);
                    socket.Data.Value = 0;
                }
        }

       
        public void conectarSockets()
        {
            foreach (Socket socket in sockets)
            {
                socket.AutoConnect = false;
                if (socket.IsConnected)
                {
                    socket.Disconnect();
                }
                
                // y escucho solamente a las banderas de SIME.
                if (socket.Acceso == "W" && socket.TipoR == "S")
                {
                    socket.EventoSocket += escucheDatoNuevo;
                    socket.Connect(socket.Url, AccessMode.ReadWriteAutoUpdate);
                }
                // EL PLC tiene que leer las condiciones iniciales.
                else if(socket.Clasificacion=="I")
                {
                    socket.Connect(socket.Url, AccessMode.Read);
                }
                // plc escribe en los tags de medidas y en sus banderas de PLC.
                else
                {
                    socket.Connect(socket.Url, AccessMode.Write);
                }
                if (!socket.IsConnected)
                {
                    MessageBox.Show("No se conecto al Socket");
                }
            }
        }
       
        private void CargarVariables()
        {
            
            Conexion conexion = new Conexion();
            //List<VariablesPLC> variables = new List<VariablesPLC>();
            int numCampos = 3;
            int y = 10;
            List<string> resultados = conexion.Consulta("select distinct(idregistro),tag,v.descripcion from linea inner join Estacion on Linea_idLinea=idlinea and e_estatus=1 and l_estatus=1 inner join registro on registro.Estacion_idestacion=idestacion and r_estatus=1 inner join variables v on v.Registro_idRegistro=idregistro and v_estatus=1 where idEstacion=" +est.idEstacion + " and v.idvariable not in(select Variables_idVariable from combinacion)", numCampos);
            for (int i = 0; i < resultados.Count; i += numCampos)
            {
                Label l = new Label();
                TextBox tb = new TextBox(); //instanciamos nuestro nuevo TextBox
                l.Location = new System.Drawing.Point(30, y);
                l.AutoSize = true;
                tb.Location = new System.Drawing.Point(115, y);
                l.Text = resultados[i + 2] + ": ";
                
                tb.Tag = resultados[i];
                panel1.Controls.Add(l);
                panel1.Controls.Add(tb); //finalmente lo agregamos a nuestro Form
                y = y + 40;
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // se busca en los sockets cual es el socket de Codigo2D para cololarle el codigo que el usuario escribio en el campo.
            foreach (Socket socket in sockets)
                if (socket.TipoR == "2D")
                {
                    socket.Data.Value = txtB1.Text;
                    socket.Update();
                }
            // Ya colocado el codigo en el socket, se procede a cambiar la bandera del plc a 1 para que SIME tome el codigo y me diga si está en secuencia.
            foreach (Socket socket in sockets)
                if (socket.TipoR == "P" && socket.Clasificacion=="L")
                {
                    socket.Data.Value = 1;
                    socket.Update();
                }           
            labelS.Text = "Leyendo codigo";
            labelP.Text = "Codigo ingresado";
        }

       

        public void cargarVariablesTag()
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void Manual_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Socket s in sockets)
            {
                s.Disconnect();
                s.Dispose();
            }
        }
        
    }
}
