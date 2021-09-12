using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Veiculos.DataAccess;

namespace Veiculos.WebAPI.Business
{
    public class CombustivelBusiness
    {
        CombustivelDAO combustivelDAO;

        public CombustivelBusiness()
        {
            combustivelDAO = new CombustivelDAO();
        }

        public DataTable Listar()
        {
            return combustivelDAO.Listar();
        }

    }
}