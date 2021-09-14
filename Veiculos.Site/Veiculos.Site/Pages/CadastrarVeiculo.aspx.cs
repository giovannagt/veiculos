using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veiculos.Models;
using Veiculos.Site.Functions;

namespace Veiculos.Site.Pages
{
    public partial class CadastrarVeiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                Session["VeiculoId"] = Convert.ToInt32(Request.QueryString["VeiculoId"]);                                   
                CarregarPagina();
            }
        }

        private void CarregarPagina()
        {
            CarregarMarcas();
            CarregarTiposVeiculo();
            CarregarCombustiveis();

            if(Convert.ToInt32(Session["VeiculoId"]) != 0) //se for alteracao
            {
                CarregarVeiculo();
            }
        }

        private async void CarregarVeiculo()
        {
            try
            {
                var IntegrationJsonString = await CallApi.Get("BuscarVeiculo/" + Session["VeiculoId"]);

                Veiculo veiculo = JsonConvert.DeserializeObject<Veiculo>(IntegrationJsonString);

                PreencherCamposTela(veiculo);                              
            }
            catch (Exception ex)
            {
                Alerta.Show(this.Page, "Erro ao carregar veículo. " + ex.Message);
            }
        }

        private void PreencherCamposTela(Veiculo info)
        {
            txtPlaca.Text = info.Placa;
            txtModelo.Text = info.Modelo;
            ddlMarca.SelectedValue = info.MarcaId.ToString();
            txtAnoFabricacao.Text = info.AnoFabricacao.ToString();
            txtAnoModelo.Text = info.AnoModelo.ToString();
            txtCor.Text = info.Cor;
            ddlTipoVeiculo.SelectedValue = info.TipoVeiculoId.ToString();
            ddlCombustivel.SelectedValue = info.CombustivelId.ToString();
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
        protected async void btnSalvar_Click(object sender, EventArgs e)
        {           
            Veiculo veiculo = new Veiculo();

            PreencherModeloVeiculo(veiculo);            

            var message = JsonConvert.SerializeObject(veiculo);

            HttpResponseMessage response = new HttpResponseMessage();

            if (veiculo.VeiculoId == 0)
            {
                response = await CallApi.Post("IncluirVeiculo", message);
            }
            else
            {                
                response = await CallApi.Put("AlterarVeiculo", message);
            }                      

            Alerta.Show(this.Page, response.ReasonPhrase);

            if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                Response.Redirect("ListarVeiculos.aspx", false);
            else
                txtPlaca.Focus();
        }

        private void PreencherModeloVeiculo(Veiculo info)
        {
            info.VeiculoId = Convert.ToInt32(Session["VeiculoId"]);
            info.Placa = txtPlaca.Text.ToUpper();
            info.Modelo = txtModelo.Text;
            info.MarcaId = Convert.ToInt32(ddlMarca.SelectedValue);
            info.AnoFabricacao = Convert.ToInt32(txtAnoFabricacao.Text);
            info.AnoModelo = Convert.ToInt32(txtAnoModelo.Text);
            info.Cor = txtCor.Text;
            info.TipoVeiculoId = Convert.ToInt32(ddlTipoVeiculo.SelectedValue);
            info.CombustivelId = Convert.ToInt32(ddlCombustivel.SelectedValue);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["VeiculoId"]) != 0)
                Response.Redirect("ListarVeiculos.aspx", false);
            else
                Response.Redirect("index.aspx", false);
        }

        
    }
}