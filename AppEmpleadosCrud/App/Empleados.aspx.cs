using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppEmpleadosCrud.App
{
    public partial class Empleados : System.Web.UI.Page
    {
        // crear objeto para gestionar datos
        GestionDatos datos = new GestionDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Empleado> listaEmpleados = datos.LeerTodos();

                GridViewEmpleados.DataSource = listaEmpleados;
                GridViewEmpleados.DataBind();
            }
        }

        protected void btnListarEmpleados_Click(object sender, EventArgs e)
        {
            List<Empleado> listaEmpleados = datos.LeerTodos();

            GridViewEmpleados.DataSource = listaEmpleados;
            GridViewEmpleados.DataBind();
        }

        protected void GridViewEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<Empleado> listaEmpleados = datos.LeerTodos();

            GridViewEmpleados.PageIndex = e.NewPageIndex;
            GridViewEmpleados.DataSource = listaEmpleados;
            GridViewEmpleados.DataBind();

        }

        protected void BtnBuscarCodigo(object sender, EventArgs e)
        {
            if (datos.ExisteEmpleado(inCodigoBuscar.Text))
            {
                Response.Redirect("Formulario.aspx?id=" + inCodigoBuscar.Text);
            } else
            {
                LabelBuscar.Text = "No existe este codigo";
            }
        }

        protected void GridViewEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Select")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                string valor = Convert.ToString(GridViewEmpleados.DataKeys[indice].Value);
                //Response.Write("Valor de fila" + indice);
                //Response.Write("Valor celda" + valor);
                Response.Redirect("Formulario.aspx?id=" + valor);
            }
        }

        protected void GridViewEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}