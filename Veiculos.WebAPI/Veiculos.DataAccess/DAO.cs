using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.DataAccess
{
    public abstract class DAO<T> where T : class
    {
        private string conexao = "Password=123456;Persist Security Info=True;User ID=sa;Initial Catalog=Veiculos;Data Source=.";

        protected SqlConnection cn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;
        protected SqlDataAdapter adapter;

        public DAO()
        {
            cn = new SqlConnection(conexao);
            cmd = new SqlCommand();
            cmd.Connection = cn;
            adapter = new SqlDataAdapter();
        }

        protected void AbrirConexao()
        {
            cn.Open();
        }

        protected void FecharConexao()
        {
            if (cn != null && cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        public abstract int Incluir(T item);

        public abstract int Alterar(T item);

        public abstract int Excluir(int id);

        public abstract DataTable Buscar(int id);

        public abstract DataTable Listar();       
    }
}
