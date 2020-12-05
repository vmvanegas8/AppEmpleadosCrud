using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace AppEmpleadosCrud
{
    public class GestionDatos
    {

        public MySqlConnection conexion;
        public string error;


        public GestionDatos()
        {
            conexion = ConexionMysql.getConexion();
        }

        public List<Empleado> LeerTodos()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

            string sql = "select * from empleados;";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader resultado = cmd.ExecuteReader();

            while (resultado.Read())
            {
                Empleado myEmpleado = new Empleado
                {
                    Codigo = resultado.GetString(1),
                    Nombre = resultado.GetString(2),
                    Apellido = resultado.GetString(3),
                    Cargo = resultado.GetString(4),
                    Salario = resultado.GetString(5),
                    Area = resultado.GetString(6),
                    Ciudad = resultado.GetString(7)
                };

                listaEmpleados.Add(myEmpleado);
            }

            resultado.Close();
            return listaEmpleados;
        }

        public Boolean ExisteEmpleado(string codigo)
        {
            string sql = "select * from empleados where codigo = @codigo";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            MySqlDataReader resultado = cmd.ExecuteReader();

            if(resultado.Read())
            {
                resultado.Close();
                return true;
            } else
            {
                resultado.Close();
                return false;
            }

        }


        // Insertar un objeto a la base de datos
        public Boolean InsertarEmpleadoBD(Empleado myEmpleado)
        {
            Boolean rta = false;

            try
            {

                string sql = "insert into empleados (codigo, nombre, apellido, cargo, salario, area, ciudad) values (@codigo, @nombre, @apellido, @cargo, @salario, @area, @ciudad)";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@codigo", myEmpleado.Codigo);
                cmd.Parameters.AddWithValue("@nombre", myEmpleado.Nombre);
                cmd.Parameters.AddWithValue("@apellido", myEmpleado.Apellido);
                cmd.Parameters.AddWithValue("@cargo", myEmpleado.Cargo);
                cmd.Parameters.AddWithValue("@salario", myEmpleado.Salario);
                cmd.Parameters.AddWithValue("@area", myEmpleado.Area);
                cmd.Parameters.AddWithValue("@ciudad", myEmpleado.Ciudad);
                cmd.ExecuteNonQuery();
                rta = true;
            }
            catch(MySqlException exception)
            {
                this.error = exception.Message;
            }

            return rta;
        }

        public Empleado consultaEmpleado(string codigo)
        {

            string sql = "select * from empleados where codigo=@codigo;";

            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            MySqlDataReader resultado = cmd.ExecuteReader();

            if (resultado.Read())
            {
                Empleado myEmpleado = new Empleado
                {
                    Codigo = resultado.GetString(1),
                    Nombre = resultado.GetString(2),
                    Apellido = resultado.GetString(3),
                    Cargo = resultado.GetString(4),
                    Salario = resultado.GetString(5),
                    Area = resultado.GetString(6),
                    Ciudad = resultado.GetString(7)
                };
                resultado.Close();
                return myEmpleado;
            } else
            {
                resultado.Close();
                return null;
            }

        }

        // Editar  un objeto a la base de datos
        public Boolean EditarEmpleadoDB(Empleado myEmpleado)
        {
            Boolean rta = false;

            try
            {

                string sql = "update empleados set nombre = @nombre, apellido = @apellido, cargo = @cargo, salario = @salario, area = @area, ciudad = @ciudad where codigo = @codigo";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@codigo", myEmpleado.Codigo);
                cmd.Parameters.AddWithValue("@nombre", myEmpleado.Nombre);
                cmd.Parameters.AddWithValue("@apellido", myEmpleado.Apellido);
                cmd.Parameters.AddWithValue("@cargo", myEmpleado.Cargo);
                cmd.Parameters.AddWithValue("@salario", myEmpleado.Salario);
                cmd.Parameters.AddWithValue("@area", myEmpleado.Area);
                cmd.Parameters.AddWithValue("@ciudad", myEmpleado.Ciudad);
                cmd.ExecuteNonQuery();
                rta = true;
            }
            catch (MySqlException exception)
            {
                this.error = exception.Message;
            }

            return rta;
        }

        // Eliminar datos de empleado

        public Boolean EliminarEmpleadoDB(string codigo)
        {
            Boolean rta = false;

            try
            {

                string sql = "delete from empleados where codigo = @codigo";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.ExecuteNonQuery();
                rta = true;
            }
            catch (MySqlException exception)
            {
                this.error = exception.Message;
            }

            return rta;
        }

    }
}