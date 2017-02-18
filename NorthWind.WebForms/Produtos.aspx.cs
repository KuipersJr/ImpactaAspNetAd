using NorthWind.Repositorios.SqlServer;
using System;

namespace NorthWind.WebForms
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void criterioPesquisaRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            criterioPesquisaMultiView.ActiveViewIndex = Convert.ToInt32(criterioPesquisaRadioButtonList.SelectedValue);
            produtosGridView.DataSourceID = $"produtosPor{criterioPesquisaRadioButtonList.SelectedItem.Text}ObjectDataSource";

            if (criterioPesquisaMultiView.ActiveViewIndex == 1 && fornecedoresDropDownList.Items.Count == 1)
            {
                fornecedoresDropDownList.DataSource = new FornecedorRepositorio().Selecionar();
                fornecedoresDropDownList.DataValueField = "SupplierId";
                fornecedoresDropDownList.DataTextField = "CompanyName";
                fornecedoresDropDownList.DataBind();
            }       
        }
    }
}