using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Veiculos.Models;
using Veiculos.WebAPI.Business;

namespace Veiculos.WebAPI.Controllers
{
    [RoutePrefix("api/Veiculo")]
    public class VeiculoController : ApiController
    {
        [HttpGet]
        [Route("ListarMarcas")]
        public IHttpActionResult ListarMarcas()
        {
            MarcaBusiness marcaBusiness = new MarcaBusiness();

            DataTable dt = marcaBusiness.Listar();            

            return Ok(dt);
        }

        [HttpGet]
        [Route("ListarTiposVeiculo")]
        public IHttpActionResult ListarTiposVeiculo()
        {
            TipoVeiculoBusiness tipoVeiculoBusiness = new TipoVeiculoBusiness();

            DataTable dt = tipoVeiculoBusiness.Listar();

            return Ok(dt);
        }

        [HttpGet]
        [Route("ListarCombustiveis")]
        public IHttpActionResult ListarCombustiveis()
        {
            CombustivelBusiness combustivelBusiness = new CombustivelBusiness();

            DataTable dt = combustivelBusiness.Listar();

            return Ok(dt);
        }

        [HttpGet]
        [Route("ListarVeiculos")]
        public IHttpActionResult ListarVeiculos()
        {
            VeiculoBusiness veiculoBusiness = new VeiculoBusiness();

            DataTable dt = veiculoBusiness.Listar();

            return Ok(dt);
        }

        [HttpPost]
        [Route("IncluirVeiculo")]
        public HttpResponseMessage IncluirVeiculo([FromBody] Veiculo veiculo)
        {
            VeiculoBusiness veiculoBusiness = new VeiculoBusiness();
            HttpResponseMessage response = new HttpResponseMessage();

            int veiculoId = veiculoBusiness.IncluirVeiculo(veiculo);            

            if (veiculoId == 0)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Veículo não cadastrado, essa placa já existe no sistema.";                
            }                
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Created);
                response.ReasonPhrase = "Veículo cadastrado com sucesso.";                
            }

            return response;
        }

        [HttpPut]
        [Route("AlterarVeiculo")]
        public HttpResponseMessage AlterarVeiculo([FromBody] Veiculo veiculo)
        {
            VeiculoBusiness veiculoBusiness = new VeiculoBusiness();
            HttpResponseMessage response = new HttpResponseMessage();

            int veiculoId = veiculoBusiness.AlterarVeiculo(veiculo);

            if (veiculoId == 0)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Erro ao alterar, essa placa já existe no sistema.";
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.ReasonPhrase = "Veículo alterado com sucesso.";
            }

            return response;
        }

        [HttpGet]
        [Route("BuscarVeiculo/{id}")]
        public Veiculo BuscarVeiculo(int id)
        {
            VeiculoBusiness veiculoBusiness = new VeiculoBusiness();

            Veiculo veiculo = veiculoBusiness.BuscarVeiculo(id);

            return veiculo;
        }

        [HttpDelete]
        [Route("ExcluirVeiculo/{id}")]
        public HttpResponseMessage Deletar(int id)
        {
            VeiculoBusiness veiculoBusiness = new VeiculoBusiness();
            HttpResponseMessage response = new HttpResponseMessage();

            int exclusao = veiculoBusiness.ExcluirVeiculo(id);

            if (exclusao == 0)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Erro ao excluir.";
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.ReasonPhrase = "Veículo excluído com sucesso.";
            }
            
            return response;
        }
    }
}
