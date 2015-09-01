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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        DataSocket socket=new DataSocket();
        private void button1_Click(object sender, EventArgs e)
        {
            string url = "opc://localhost/Kepware.KEPServerEX.V5/Estacion10.PLC." + textBox1.Text;

            socket.AutoConnect = false;
            
            if (socket.IsConnected)
                socket.Disconnect();
            socket.Connect(url, AccessMode.ReadWriteAutoUpdate);
            socket.DataUpdated += new DataUpdatedEventHandler(socket_DataUpdated);
            if (!socket.IsConnected)
                MessageBox.Show("No se conecto al Socket");

            
            socket.Data.Value = textBox2.Text;
            //MessageBox.Show("Mensaje enviado");
        }

        void socket_DataUpdated(object sender, DataUpdatedEventArgs e)
        {
            if(e.Data.Value.ToString()=="1")
                MessageBox.Show("Escuche tu dato, SIME!!! "+e.Data.Value);
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            PLC p = new PLC();
            p.ShowDialog();
            
        }

        
    }

    /*public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSocket socket = new DataSocket();
        private void button1_Click(object sender, EventArgs e)
        {
            String[] tags = { "prueba", "Alabeo", "Altura", "ancho" };
            String valor = "Estacion10.PLC.";

            for (int i = 0; i < tags.Length; i++)
            {
                string s = tags[i];
                Console.WriteLine("opc://localhost/Kepware.KEPServerEX.V5/" + valor + s);


                string url = "opc://localhost/Kepware.KEPServerEX.V5/" + valor + s;

                socket.AutoConnect = false;

                if (socket.IsConnected)
                    socket.Disconnect();
                socket.Connect(url, AccessMode.ReadWriteAutoUpdate);
                socket.DataUpdated += new DataUpdatedEventHandler(socket_DataUpdated);
                if (!socket.IsConnected)
                    MessageBox.Show("No se conecto al Socket");

                socket.Data.Value = textBox2.Text;
                //MessageBox.Show("Mensaje enviado");
            }
        }

        void socket_DataUpdated(object sender, DataUpdatedEventArgs e)
        {
            if (e.Data.Value.ToString() == "1")
                MessageBox.Show("Escuche tu dato, SIME!!! " + e.Data.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }*/
}
