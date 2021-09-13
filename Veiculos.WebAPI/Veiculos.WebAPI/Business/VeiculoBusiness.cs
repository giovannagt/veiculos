using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Veiculos.DataAccess;
using Veiculos.Models;

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

        public int IncluirVeiculo(Veiculo veiculo)
        {
            Veiculo veiculoExistente = veiculoDAO.BuscarVeiculo(0, veiculo.Placa); //busca veiculo pela placa

            if (veiculoExistente.VeiculoId > 0)
                return 0; //ja existente, nao inclui
            else
                return veiculoDAO.Incluir(veiculo);
        }

        public Veiculo BuscarVeiculo(int veiculoId)
        {
            return veiculoDAO.BuscarVeiculo(veiculoId, null); //busca veiculo pelo ID
        }

        public int AlterarVeiculo(Veiculo veiculo)
        {
            Veiculo veiculoExistente = veiculoDAO.BuscarVeiculo(0, veiculo.Placa); //busca veiculo pela placa

            if (veiculoExistente.VeiculoId != veiculo.VeiculoId && veiculoExistente.VeiculoId > 0)
                return 0; //ja existente outro veiculo com essa placa, nao deixa alterar
            else
                return veiculoDAO.Alterar(veiculo);
        }

        public int ExcluirVeiculo(int veiculoId)
        {
            Veiculo veiculo = veiculoDAO.BuscarVeiculo(veiculoId, null); //busca veiculo pelo ID

            if (veiculo.VeiculoId > 0)
                return veiculoDAO.Excluir(veiculoId);
            else
                return 0;
        }
    }
}