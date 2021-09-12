using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Veiculos.DataAccess;

namespace Veiculos.WebAPI.Business
{
    public class TipoVeiculoBusiness
    {
        private TipoVeiculoDAO tipoVeiculoDAO;

        public TipoVeiculoBusiness()
        {
            tipoVeiculoDAO = new TipoVeiculoDAO();
        }

        public DataTable Listar()
        {
            return tipoVeiculoDAO.Listar();
        }
    }
}