using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace AppEmpleadosCrud.App
{
    public class ValidarCajas
    {
        public Boolean Vacio (TextBox caja, Label error, string mensajeError)
        {
            if(caja.Text == "")
            {
                error.Text = mensajeError;
                caja.Focus();
                return true;
            }
            else
            {
                error.Text = "";
                return false;
            }
        }

        public Boolean TipoTexto(TextBox caja, Label error, string mensajeError)
        {
            Regex formato = new Regex(@" ^[a - zA - Z] + $");

            if (formato.IsMatch(caja.Text))
            {
                error.Text = mensajeError;
                caja.Focus();
                return true;
            }
            else
            {
                error.Text = "";
                return false;
            }
        }
    }
}