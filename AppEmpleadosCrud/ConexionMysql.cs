using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace AppEmpleadosCrud
{
    public class ConexionMysql
    {

        private static MySqlConnection ObjetoConexion;
        private static string error;

        public static MySqlConnection getConexion()
        {
            if (ObjetoConexion != null)
            {
                return ObjetoConexion;
            }

            ObjetoConexion = new MySqlConnection("Server=localhost;Database=sena2020;Uid=usersena;Pwd=sena2020");
            try
            {
                ObjetoConexion.Open();
                return ObjetoConexion;

            } catch (Exception e)
            {
                error = e.Message;
                return null;
            }
        }

        public static void cerrarConexion()
        {
            if(ObjetoConexion != null)
            {
                ObjetoConexion.Close();
            }
        }
    }
}