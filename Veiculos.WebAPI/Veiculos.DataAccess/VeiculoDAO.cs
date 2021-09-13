using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Models;

namespace Veiculos.DataAccess
{
    public class VeiculoDAO : DAO<Veiculo>
    {
        public override int Alterar(Veiculo veiculo)
        {
            try
            {
                AbrirConexao();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_alterarVeiculo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VeiculoId", veiculo.VeiculoId);
                cmd.Parameters.AddWithValue("@Placa", veiculo.Placa);
                cmd.Parameters.AddWithValue("@MarcaId", veiculo.MarcaId);
                cmd.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                cmd.Parameters.AddWithValue("@AnoFabricacao", veiculo.AnoFabricacao);
                cmd.Parameters.AddWithValue("@AnoModelo", veiculo.AnoModelo);
                cmd.Parameters.AddWithValue("@Cor", veiculo.Cor);
                cmd.Parameters.AddWithValue("@TipoVeiculoId", veiculo.TipoVeiculoId);
                cmd.Parameters.AddWithValue("@CombustivelId", veiculo.CombustivelId);

                int veiculoId = Convert.ToInt32(cmd.ExecuteNonQuery());

                return veiculoId;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }        

        public override DataTable Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public override int Excluir(int id)
        {
            try
            {
                AbrirConexao();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_excluirVeiculo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VeiculoId", id);                

                int veiculoId = Convert.ToInt32(cmd.ExecuteNonQuery());

                return veiculoId;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public override int Incluir(Veiculo veiculo)
        {
            try
            {                
                AbrirConexao();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_incluirVeiculo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Placa", veiculo.Placa);
                cmd.Parameters.AddWithValue("@MarcaId", veiculo.MarcaId);
                cmd.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                cmd.Parameters.AddWithValue("@AnoFabricacao", veiculo.AnoFabricacao);
                cmd.Parameters.AddWithValue("@AnoModelo", veiculo.AnoModelo);
                cmd.Parameters.AddWithValue("@Cor", veiculo.Cor);
                cmd.Parameters.AddWithValue("@TipoVeiculoId", veiculo.TipoVeiculoId);
                cmd.Parameters.AddWithValue("@CombustivelId", veiculo.CombustivelId);                

                int veiculoId = Convert.ToInt32(cmd.ExecuteScalar());
                
                return veiculoId;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public Veiculo BuscarVeiculo(int veiculoId, string placa)
        {
            try
            {
                Veiculo veiculo = new Veiculo();

                AbrirConexao();
                cmd.CommandText = "sp_buscarVeiculo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Placa", placa == null ? (object)DBNull.Value : placa);
                cmd.Parameters.AddWithValue("@VeiculoId", veiculoId);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    veiculo.VeiculoId = (int)reader["VeiculoId"];
                    veiculo.Placa = (string)reader["Placa"];
                    veiculo.MarcaId = (int)reader["MarcaId"];
                    veiculo.Modelo = (string)reader["Modelo"];
                    veiculo.AnoFabricacao = (int)reader["AnoFabricacao"];
                    veiculo.AnoModelo = (int)reader["AnoModelo"];
                    veiculo.Cor = (string)reader["Cor"];
                    veiculo.TipoVeiculoId = (int)reader["TipoVeiculoId"];
                    veiculo.CombustivelId = (int)reader["CombustivelId"];
                }                             

                return veiculo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public override DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                AbrirConexao();
                cmd.CommandText = "sp_listarVeiculos";
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
