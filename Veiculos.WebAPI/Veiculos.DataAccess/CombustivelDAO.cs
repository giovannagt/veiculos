using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Models;

namespace Veiculos.DataAccess
{
    public class CombustivelDAO :DAO<Combustivel>
    {
        public override int Alterar(Combustivel item)
        {
            throw new NotImplementedException();
        }

        public override DataTable Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public override int Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override int Incluir(Combustivel item)
        {
            throw new NotImplementedException();
        }

        public override DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                AbrirConexao();
                cmd.CommandText = "sp_listarCombustiveis";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }

            return dt;
        }
    }
}
