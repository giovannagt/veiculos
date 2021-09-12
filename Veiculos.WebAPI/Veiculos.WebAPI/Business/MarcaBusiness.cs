using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Veiculos.DataAccess;

namespace Veiculos.WebAPI.Business
{
    public class MarcaBusiness
    {
        private MarcaDAO marcaDAO;        

        public MarcaBusiness()
        {
            marcaDAO = new MarcaDAO();            
        }

        public DataTable Listar()
        {
            return marcaDAO.Listar();             
        }       
    }
}