<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="NorthWind.WebForms.Produtos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Produtos</h2>
            <div class="btn-group">
                <button type="button" class="btn btn-default" id="tipoPesquisaButton">Categorias</button>
                <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                    <span class="caret"></span>
                    <!-- caret -->
                    <span class="sr-only">Toggle Dropdown</span>
                </button>
                <ul class="dropdown-menu" role="menu" id="tipoPesquisaUl">
                    <li><a href="#">Fornecedores</a></li>
                    <li><a href="#">Categorias</a></li>
                </ul>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#tipoPesquisaUl").on('click', 'li a', function () {
                $("#tipoPesquisaButton").text($(this).text());
            });

            //$(".dropdown-menu").on('click', 'li a', function () {
            //    $(".btn:first-child").text($(this).text());
            //    $(".btn:first-child").val($(this).text());
            //});
        });
    </script>
</asp:Content>
