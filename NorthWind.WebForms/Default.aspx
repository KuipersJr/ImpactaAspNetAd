<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NorthWind.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Northwind Traders</h1>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>Produtos</h2>
            <p>
                Encontre seu produto em nossa galeria, pesquisando por categoria ou fornecedor.
            </p>
            <p>
                <a class="btn btn-default" href="Produtos">Pesquisar</a>
            </p>
        </div>
    </div>
</asp:Content>
