<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="NorthWind.WebForms.Produtos" %>

<asp:Content ID="produtosContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        #MainContent_criterioPesquisaRadioButtonList label {
            font-weight: normal;
            padding-right: 10px;
        }
    </style>
    <h2>Produtos</h2>
    <div class="row">
        <div class="col-md-12">
            Pesquisar por
            <asp:RadioButtonList ID="criterioPesquisaRadioButtonList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True"
                OnSelectedIndexChanged="criterioPesquisaRadioButtonList_SelectedIndexChanged">
                <asp:ListItem Text="Categoria" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Fornecedor" Value="1"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:MultiView ID="criterioPesquisaMultiView" runat="server" ActiveViewIndex="0">
                <asp:View runat="server" ID="categoriaView">
                    <asp:DropDownList ID="categoriasDropDownList" runat="server" DataSourceID="categoriasObjectDataSource" 
                        DataValueField="CategoryId"
                        DataTextField="CategoryName" AutoPostBack="True" AppendDataBoundItems="true">
                        <asp:ListItem Text="Selecione uma categoria" Value="0" />
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="categoriasObjectDataSource" runat="server" 
                        TypeName="NorthWind.Repositorios.SqlServer.CategoriaRepositorio"
                        SelectMethod="Selecionar"></asp:ObjectDataSource>
                </asp:View>
                <asp:View runat="server" ID="fornecedorView">
                    <asp:DropDownList ID="fornecedoresDropDownList" runat="server" AppendDataBoundItems="true" AutoPostBack="true" 
                        DataTextField="CompanyName"
                        DataValueField="SupplierId">
                        <asp:ListItem Text="Selecione um fornecedor" Value="0" />
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="fornecedorObjectDataSource" runat="server" TypeName="NorthWind.Repositorios.SqlServer.FornecedorRepositorio"
                        SelectMethod="Obter"></asp:ObjectDataSource>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="produtosGridView" runat="server" DataSourceID="produtosPorCategoriaObjectDataSource" AutoGenerateColumns="false" Width="100%" AllowPaging="True" AllowSorting="True" CssClass="gridView">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Produto" SortExpression="ProductName"></asp:BoundField>
                    <asp:BoundField DataField="UnitPrice" HeaderText="Pre&#231;o" SortExpression="UnitPrice" DataFormatString="{0:C}">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="UnitsInStock" HeaderText="Estoque" SortExpression="UnitsInStock">
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundField>
                </Columns>
                <PagerSettings Mode="NumericFirstLast" />
                <SortedAscendingHeaderStyle CssClass="sortasc" />
                <SortedDescendingHeaderStyle CssClass="sortdesc" />
            </asp:GridView>
            <asp:ObjectDataSource ID="produtosPorCategoriaObjectDataSource" TypeName="NorthWind.Repositorios.SqlServer.ProdutoRepositorio" SelectMethod="ObterPorCategoria" runat="server">
                <SelectParameters>
                    <asp:ControlParameter ControlID="categoriasDropDownList" PropertyName="SelectedValue" Name="categoriaId" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="produtosPorFornecedorObjectDataSource" TypeName="NorthWind.Repositorios.SqlServer.ProdutoRepositorio" SelectMethod="ObterPorFornecedor" runat="server">
                <SelectParameters>
                    <asp:ControlParameter ControlID="fornecedoresDropDownList" PropertyName="SelectedValue" Name="fornecedorId" Type="Int32"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
