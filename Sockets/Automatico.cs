using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sockets.Model;
using NationalInstruments.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Sockets
{
    public partial class Automatico : Form
    {
        private Form anterior;
        private List<Folio> folios;
        private List<Socket> sockets;
        private Queue<Folio> foliosProc;
        private Estacion est;

        private short[] programa = null;
        private int[] posicion = null;
        private short[] archivos = null;
        private short[] alabeo = null;
        private short[] lvdt = null;
        private int nvecesPrograma = 0;
        private int tamPrograma=1;
        private int modo;
        private bool siguientePieza = false;

        public Automatico(Estacion estacion, Linea linea, Form ant)
        {
            anterior = ant;
            est = estacion;
            InitializeComponent();
            lst_folios.DisplayMember = "Codigo2D";

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
                    object dato;
                    soc.Update();
                    switch (soc.TipoR)
                    {

                        case "modelo":
                            dato = soc.Data.Value;
                            label.Text = "" + dato;
                            break;
                        case "modo":
                            modo=Convert.ToInt32(soc.Data.Value);
                            label11.Text = "" + Constantes.Modos[modo-1];
                            break;
                            /*
                        case "prog":
                            programa = (short[])soc.Data.Value;
                            break;
                             */ 
                        case "pos":
                            posicion = (int[])soc.Data.Value;
                            break;
                            /*
                        case "file":
                            archivos = (short[])soc.Data.Value;
                            break;
                        case "lvdt":
                            lvdt = (short[])soc.Data.Value;
                            break;
                        case "ntotal":
                            break;
                        case "alabeo":
                            alabeo = (short[])soc.Data.Value;
                            break;
                             * */
                    }
                }
            }
            if (posicion == null)
            {
                lb_programas.Text = "0/"+tamPrograma;
            }
            else
            {
                foreach(int prog in posicion)
                {
                    if (prog == -1)
                        break;
                    tamPrograma++;
                }
                lb_programas.Text = "0/" + tamPrograma;
            }
        }

        private List<Socket> CargarTag()
        {
            Conexion conexion = new Conexion();
            List<Socket> tags = new List<Socket>();
            int numCampos = 5;
            List<String> resultados = conexion.Consulta("select idregistro,tag,tipor,acceso,clasificacion from registro inner join tiporeg on idregistro=Registro_idregistro where Estacion_idEstacion=" + est.idEstacion + " and r_estatus=1 order by clasificacion,idRegistro", numCampos);
            for (int i = 0; i < resultados.Count; i += numCampos)
            {
                Socket tag = new Socket(est.URL);
                tag.IdRegistro = Convert.ToInt32(resultados[i]);
                tag.Tag = resultados[i + 1];
                tag.Url += tag.Tag;
                tag.TipoR = resultados[i + 2];
                tag.Acceso = resultados[i + 3];
                tag.Clasificacion = resultados[i + 4];

                tags.Add(tag);
            }
            return tags;
        }
        private int[] respuestasSIME=new int[]{1,2,3,4};
        private void escucheDatoNuevo(object sender)
        {
            Socket socket = (Socket)sender;
            // bandera de sime del LECTOR.
            int pos=(int)socket.Data.Value;
            if (socket.TipoR == "S" && socket.Clasificacion == "L")
                if (respuestasSIME.Contains(pos))
                {
                    string codigo = dg_procesados.Rows[dg_procesados.Rows.Count - 1].Cells[0].Value+"";
                    Thread.Sleep(Constantes.TimpoLeyendoCodigo);
                    int posCodigoGrid = lst_folios.FindString(codigo, 0);
                    dg_procesados.Rows[posCodigoGrid].Cells[1].Value = Constantes.estadosLectorPLC[pos - 1];
                    dg_procesados.Rows[posCodigoGrid].Cells[2].Value = Constantes.estadosLectorSIME[pos - 1];
                   
                    socket.Data.Value = 0;
                    if (pos == 2)
                        foliosProc.Dequeue();
                }


            //bandera de sime de MEDICIONES
            if (socket.TipoR == "S" && socket.Clasificacion == "M")
                if (respuestasSIME.Contains(pos))
                {
                    lb_programas.Text = nvecesPrograma + "/" + tamPrograma;
                    if (nvecesPrograma != tamPrograma )
                    {
                        int posCodigoGrid = lst_folios.FindString(((Folio)foliosProc.Peek()).Codigo2D, 0);
                        dg_procesados.Rows[posCodigoGrid].Cells[1].Value = "Capturando Mediciones";
                        dg_procesados.Rows[posCodigoGrid].Cells[2].Value = "Esperando Mediciones";
                        nvecesPrograma++;

                    }
                    else
                    {
                        //se muestra estado de la pieza a medir en la tabla.
                        int posCodigoGrid = lst_folios.FindString(((Folio)foliosProc.Peek()).Codigo2D, 0);
                        dg_procesados.Rows[posCodigoGrid].Cells[1].Value = Constantes.estadosMediPLC[pos - 1];
                        dg_procesados.Rows[posCodigoGrid].Cells[2].Value = Constantes.estadosMediSIME[pos - 1];
                        // al acabarse los programas el resultado de la bandera es 1.- Pieza correcta, 2.- pieza incorrecta, 4.- no se pudo medir pieza
                        // en cualquiera de los casos anteriores el proceso de la pieza termino y por tanto se quita ese codigo dela cola de procesos.
                        //sino quiere decir que huvo algun error en una medicion y el plc tiene que volver a poner las mediciones.
                        if (pos != 3)
                        {
                            foliosProc.Dequeue();
                            nvecesPrograma = 0;
                            siguientePieza = true;
                        }
                        else
                        {
                            // el plc vuelve a repetir el programa y vuelve a colocar las mediciones.
                        }
                    }

                    Thread.Sleep(1000);
                    socket.Data.Value = 0;
                }
        }
        private void EmpiezaMedir()
        {
            for (int i = 0; i < lst_folios.Items.Count; i++)
            {
                Folio fol = foliosProc.Peek();
                ponerMedidas(fol);
                // se espera con el while hasta que el folio primero de la cola haya sido procesado.
                // cuando la pieza haya sido procesada entonces se sale del while y continua con otra pieza a ser procesada.

                while (!siguientePieza)
                {
                }
                siguientePieza = false; 
            }
        }
        private void ponerMedidas(Folio cod)
        {
           
            //Tiempo aproximado que tarda la estacion en tomar la pieza y colocarlo en los instrumentos de medicion.
            Thread.Sleep(Constantes.TiempoProceso);
            // ya que la pieza fue aceptada en la estacion, entonces se colocan las medidas en los tags para que sime las tome.
            foreach (Medida medi in cod.Medidas)
            {
                foreach (Socket soc in sockets)
                {
                    if (medi.IdRegistro == soc.IdRegistro)
                    {
                        soc.Data.Value = medi.Valor;
                        soc.Update();
                        break;
                    }
                }
            }
            // ya que termina la estacion de capturar todas las medidas, entonces le dice a SIME que las medidas estan listas
            // para que las tome.
            foreach (Socket s in sockets)
            {
                if (s.Clasificacion == "M" && s.TipoR == "P")
                {
                    s.Data.Value = 1;
                    s.Update();
                    break;
                }
            }
            nvecesPrograma++;
            
           
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
                    socket.Data.Value = 0;
                }
                // EL PLC tiene que leer las condiciones iniciales.
                else if (socket.Clasificacion == "I")
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
            List<string> resultados = conexion.Consulta("select distinct(idregistro),tag,v.descripcion from linea inner join Estacion on Linea_idLinea=idlinea and e_estatus=1 and l_estatus=1 inner join registro on registro.Estacion_idestacion=idestacion and r_estatus=1 inner join variables v on v.Registro_idRegistro=idregistro and v_estatus=1 where idEstacion=" + est.idEstacion + " and v.idvariable not in(select Variables_idVariable from combinacion)", numCampos);
            for (int i = 0; i < resultados.Count; i += numCampos)
            {
                Label l = new Label();
                TextBox tb = new TextBox(); //instanciamos nuestro nuevo TextBox
                l.Location = new System.Drawing.Point(30, y);
                l.AutoSize = true;
                tb.Location = new System.Drawing.Point(115, y);
                l.Text = resultados[i + 2] + ": ";

                tb.Tag = resultados[i];
                pnl_variables.Controls.Add(l);
                pnl_variables.Controls.Add(tb); //finalmente lo agregamos a nuestro Form
                y = y + 40;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            lst_folios.Items.Clear();
            dg_procesados.Rows.Clear();
            btn_iniciar.Enabled = true;
            btn_terminar.Enabled = false;
            nvecesPrograma = 0;
            lb_programas.Text = nvecesPrograma + "/" + tamPrograma;
        }

        private void Automatico_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Socket s in sockets)
            {
                s.Disconnect();
                s.Dispose();
            }
            anterior.Visible = true;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            /*
             *  obtenemos una lista de las variables.
             **/
            List<Medida> medidas = new List<Medida>();
            foreach (Control ctrlHijo in pnl_variables.Controls)
            {
                Type tipo = ctrlHijo.GetType();
                if (tipo.Name == "TextBox")
                {
                    Medida med = new Medida();
                    med.IdRegistro = Convert.ToInt32(ctrlHijo.Tag);
                    med.Valor = (ctrlHijo.Text!="")?ctrlHijo.Text:"0";
                    medidas.Add(med);
                    ctrlHijo.Text = "";
                }

            }

            Folio folioCodigo = new Folio();
            folioCodigo.Codigo2D = txt_codigo.Text;
            folioCodigo.Medidas = medidas;
            lst_folios.Items.Add(folioCodigo);

            txt_codigo.Text = "";

        }

        private void Automatico_Load(object sender, EventArgs e)
        {
            lb_folio.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_iniciar.Enabled = false;
            btn_terminar.Enabled = true;
            int Milisegundos = Convert.ToInt32("0"+txt_tiempo.Text);
            Milisegundos=(Milisegundos<1000)?1000:Milisegundos;
            foliosProc = new Queue<Folio>();

            foreach(object f in lst_folios.Items)
            {
                Folio folio = (Folio)f;
                foliosProc.Enqueue(folio);
                Thread.Sleep(Convert.ToInt32(Milisegundos));
                dg_procesados.Rows.Add(folio.Codigo2D, "Codigo enviado", "Validando Codigo");
                // se coloca en el socket del codigo de la pieza.
                foreach (Socket s in sockets)
                {
                    if (s.TipoR == "2D")
                    {
                        s.Data.Value = folio.Codigo2D;
                        s.Update();
                        break;
                    }
                }
                // ya colocado el codigo de la pieza, procede a decirle a sime que ya puede leer el codigo de la pieza
                foreach (Socket s in sockets)
                {
                    if (s.Clasificacion == "L" && s.TipoR == "P")
                    {
                        s.Data.Value = 1;
                        s.Update();
                        break;
                    }
                }
                // si es modo calibracion solamente una pieza entra a la Estacion.
                if (modo == 1)
                    break;
            }
            // ya que entra la pieza o piezas a la estación, entonces se inicia el proceso de medición de una por una de las que entraron.
            Task tarea=new Task(()=>EmpiezaMedir());
            tarea.Start();
            
        }
       
    }
}
