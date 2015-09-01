using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Data;
using System.Diagnostics;

namespace Sockets
{
    public class Conexion
    {
        private string[] datos;//arreglo para almacenar los datos de conexion a la base de datos.
        /*
         *  0.- user
         *  1.- password
         *  2.- base
         *  3.- server
         */
        private MySqlConnection connection = null;
        private string datosConexion = "";

        
        //MySqlDataReader -----> para retornar de tipo Mysql 
        public List<string> Consulta(string query, int param)
        {
            MySqlDataReader resultado = null;
            List<string> lista = new List<string>();
            //si se puede conectar entonces realiza la consulta.
            if (isConected())
            {
                lista = new List<string>();
                MySqlCommand cmd = new MySqlCommand(query, this.connection);
                resultado = cmd.ExecuteReader();
                /*
                 * proceso para llenar la lista a retornar.
                 * 
                 */
                while (resultado.Read())
                {
                    //lista.Add(resultado["id"] + ""); lista.Add(resultado["nombre"] + ""); lista.Add(resultado["edad"] + "");
                    //for para agregar cada valor del campo.
                    for (int i = 0; i < param; i++)
                    {
                        lista.Add(resultado[i] + "");
                    }
                }
                resultado.Close();// para el llenado de la lista.
                /*
                 * fin de proceso de llenar la lista.
                 */
                //return resultado;
                //close conection.
                this.Cerrar();// para tipo llenar lista.
                return lista;
            }
            else
                //return resultado;
                return lista;
        }
        //metodo para validar si se puso conectar a la base de datos.
        private bool isConected()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexion \n\n" + ex.Message);
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        //Cerrar la conexion.
        public void Cerrar()
        {
            try
            {
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("NO SE PUEDO CERRAR LA CONEXION" + ex.Message);
            }
        }
        public Conexion()
        {
            
            datosConexion = "server=" + "localhost" + "; user id=" + "root" + "; password=" + "seguridad" + "; database=" + "sime2" + "; pooling=false;";
            this.conecta(datosConexion);
        }

        private void conecta(string datos)
        {
            try
            {
                connection = new MySqlConnection(datos);
                //Console.WriteLine("MySQL version : {0}", connection.ServerVersion);
            }
            catch (MySqlException ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                MessageBox.Show("Error de conexion" + ex.Message);
            }
        }
       
    }
}


