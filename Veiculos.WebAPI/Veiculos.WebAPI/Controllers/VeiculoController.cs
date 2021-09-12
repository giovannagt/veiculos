using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
    }
}
