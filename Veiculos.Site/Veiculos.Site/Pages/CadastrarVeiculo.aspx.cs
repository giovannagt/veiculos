using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veiculos.Site.Functions;

namespace Veiculos.Site.Pages
{
    public partial class CadastrarVeiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarPagina();
            }
        }

        private void CarregarPagina()
        {
            CarregarMarcas();
            CarregarTiposVeiculo();
            CarregarCombustiveis();
        }

        private async void CarregarMarcas()
        {
            try
            {
                var IntegrationJsonString = await CallApi.Get("ListarMarcas");                

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(IntegrationJsonString, (typeof(DataTable)));
                
                ddlMarca.DataSource = dt;
                ddlMarca.DataTextField = "Descricao";
                ddlMarca.DataValueField = "MarcaId";
                ddlMarca.DataBind();

                ddlMarca.Items.Insert(0, new ListItem("Selecione...", "0"));                
            }
            catch (Exception ex)
            {
                Alerta.Show(this.Page, "Erro ao carregar marcas. " + ex.Message);
            }
        }

        private async void CarregarTiposVeiculo()
        {
            try
            {
                var IntegrationJsonString = await CallApi.Get("ListarTiposVeiculo");

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(IntegrationJsonString, (typeof(DataTable)));

                ddlTipoVeiculo.DataSource = dt;
                ddlTipoVeiculo.DataTextField = "Descricao";
                ddlTipoVeiculo.DataValueField = "TipoVeiculoId";
                ddlTipoVeiculo.DataBind();

                ddlTipoVeiculo.Items.Insert(0, new ListItem("Selecione...", "0"));
            }
            catch (Exception ex)
            {

                Alerta.Show(this.Page, "Erro ao carregar os tipos do veículo. " + ex.Message);
            }
        }

        private async void CarregarCombustiveis()
        {
            try
            {
                var IntegrationJsonString = await CallApi.Get("ListarCombustiveis");

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(IntegrationJsonString, (typeof(DataTable)));

                ddlCombustivel.DataSource = dt;
                ddlCombustivel.DataTextField = "Descricao";
                ddlCombustivel.DataValueField = "CombustivelId";
                ddlCombustivel.DataBind();

                ddlCombustivel.Items.Insert(0, new ListItem("Selecione...", "0"));
            }
            catch (Exception ex) 
            {

                Alerta.Show(this.Page, "Erro ao carregar combustíveis. " + ex.Message);
            }
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx", false);
        }

        
    }
}