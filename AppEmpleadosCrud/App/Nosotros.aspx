<%@ Page Title="" Language="C#" MasterPageFile="~/App/Layout.Master" AutoEventWireup="true" CodeBehind="Nosotros.aspx.cs" Inherits="AppEmpleadosCrud.App.Nosotros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="textoH1"> nuetro equipo de trabajo  </h1>
    <main class="estiloMain">
        <div class="contenedorCards">
                 <!-- inicio  cards-->
                 <div class="cards material-shadow">
                    <div>
                        <img class="picProgramador" src="./pic/programador.jpg" alt="">
                    </div>
                    <div>         
                    <p class="textoResaltado"> Nombre </p>
                    <p class="textoNormal"> Gal Maria Galod de los Angales</p>
                    <p class="textoResaltado"> Correo </p>
                    <p class="textoNormal">galmaria@gmail.com</p>
                    </div>
                </div>
                <!-- final cards-->  
        </div>      
    </main>

</asp:Content>
