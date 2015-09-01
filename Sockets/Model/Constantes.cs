using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sockets.Model
{
    public static class Constantes
    {
        public static string[] estadosLectorSIME = new string[2] { "Secuencia OK", "Secuencia Incorrecta" };
        public static string[] estadosLectorPLC = new string[2] { "Ingresa Campana a Estacion", "Retiene Campana" };
        public static string[] estadosMediSIME = new string[5] { "Campana aceptada", "Campana rechazada","Siguiente Programa", "Volver a Intentar", "Intentos Fallidos Medidas" };
        public static string[] estadosMediPLC = new string[5] { "Continua flujo", "Expulsarla al contenedor","Ejecutando Programa", "Volviendo a Capturar Medidas", "Continua flujo" };
        public static int TiempoProceso = 3000;
        public static int TimpoLeyendoCodigo = 1000;
        public static string[] Modos = new string[3] {"Calibración","Producción","Ajuste"};
        
    }
}
