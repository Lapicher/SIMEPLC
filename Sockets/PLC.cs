using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sockets
{
    public partial class PLC : Form
    {
        public PLC()
        {
            //Conexion.ObtenerConexion();
            //MessageBox.Show("Conectado!");
            InitializeComponent();
        }

        private List<Estacion> CargarEstacion()
        {

            Conexion conexion = new Conexion();
            List<Estacion> estaciones = new List<Estacion>();
            int numCampos=3;
            List<string> resultados = conexion.Consulta("select nombreEstacion,idestacion,url from estacion where linea_idlinea="+((Linea)cboxL.SelectedItem).idLinea, numCampos);
            for (int i = 0; i < resultados.Count; i += numCampos)
            {
                Estacion estacion = new Estacion();
                estacion.NombreEstacion = resultados[i];
                estacion.idEstacion = Convert.ToInt32(resultados[i + 1]);
                estacion.URL = resultados[i + 2];
                estaciones.Add(estacion);
            }
            return estaciones;
        }
        
        private List<Linea> CargarLinea()
        {
            Conexion conexion = new Conexion();
            List<Linea> lineas = new List<Linea>();
            int numCampos=2;
            List<string> resultados = conexion.Consulta("select Nombre_linea, idLinea from linea where l_estatus=1", numCampos);
            for (int i = 0; i < resultados.Count; i += numCampos)
            {
                Linea linea = new Linea();
                linea.Nombre_linea = resultados[i];
                linea.idLinea = Convert.ToInt32(resultados[i + 1]);
                lineas.Add(linea);
            }

            return lineas;
        }

        private void PLC_Load(object sender, EventArgs e)
        {
           
            cboxL.DataSource = CargarLinea();
            cboxL.DisplayMember = "Nombre_linea";
            cboxL.ValueMember = "idLinea";
            rBtnM.Checked = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estacion estacionSeleccionada =(Estacion) cboxE.SelectedItem;
            Linea LineaSeleccionada =(Linea) cboxL.SelectedItem;

            if (rBtnM.Checked)
            {
                Manual ventana = new Manual(estacionSeleccionada, LineaSeleccionada);
                ventana.Visible = true;
            }
            else
            {
                Automatico ventana = new Automatico(estacionSeleccionada, LineaSeleccionada,this);
                ventana.Visible = true;
                this.Visible = false;
            }
        }

        private void cboxL_TextChanged(object sender, EventArgs e)
        {
            cboxE.DataSource = CargarEstacion();
            cboxE.DisplayMember = "NombreEstacion";
            cboxE.ValueMember = "idEstacion";
        }

        
    }
}
