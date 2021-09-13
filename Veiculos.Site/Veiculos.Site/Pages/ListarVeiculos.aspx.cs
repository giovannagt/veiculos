using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veiculos.Site.Functions;

namespace Veiculos.Site.Pages
{
    public partial class ListarVeiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaRepeater();
            }
        }

        private async void CarregaRepeater()
        {
            try
            {
                var IntegrationJsonString = await CallApi.Get("ListarVeiculos");                                    

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(IntegrationJsonString, (typeof(DataTable)));

                gridVeiculos.DataSource = dt;
                gridVeiculos.DataBind();                                
            }
            catch (Exception ex)
            {
                Alerta.Show(this.Page, ex.Message);
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            var id = ((Button)sender).CommandArgument;

            Response.Redirect("CadastrarVeiculo.aspx?VeiculoId=" + id, false);
        }

        protected async void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = ((Button)sender).CommandArgument;

            HttpResponseMessage response = await CallApi.Delete("ExcluirVeiculo/" + id);                        

            if (response.StatusCode == HttpStatusCode.OK)
            {
                CarregaRepeater();
            }
        }
    }
}