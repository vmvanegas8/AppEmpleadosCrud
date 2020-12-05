<%@ Page Title="" Language="C#" MasterPageFile="~/App/Layout.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="AppEmpleadosCrud.App.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="textoH1"> crud basico a una tabla html  </h1>
    <main class="estiloMain">
        <div class="contendeorApp"> 
        <div class="menuApp"> 
        <div class="contenedorBtnApp">
        <div><asp:TextBox ID="inCodigoBuscar" runat="server"></asp:TextBox></div>
        <div><asp:Button CssClass="menuLink" ID="Button1" runat="server" OnClick="BtnBuscarCodigo" Text="Buscar empleado" /></div>
        <div><asp:Label ID="LabelBuscar" runat="server" Text=""></asp:Label></div>
        </div>
        </div>
        <div class="contenedorDatos">
        <asp:GridView ID="GridViewEmpleados" CssClass="my-grid-view" runat="server" AllowPaging="True" OnPageIndexChanging="GridViewEmpleados_PageIndexChanging" DataKeyNames="Codigo" OnRowCommand="GridViewEmpleados_RowCommand" OnSelectedIndexChanged="GridViewEmpleados_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Seleccionar" />
            </Columns>
         </asp:GridView>
        </div>
    </div>
    </main>
</asp:Content>
