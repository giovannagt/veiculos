using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Veiculos.DataAccess;

namespace Veiculos.WebAPI.Business
{
    public class VeiculoBusiness
    {
        VeiculoDAO veiculoDAO;

        public VeiculoBusiness()
        {
            veiculoDAO = new VeiculoDAO();
        }

        public DataTable Listar()
        {
            return veiculoDAO.Listar();
        }
    }
}