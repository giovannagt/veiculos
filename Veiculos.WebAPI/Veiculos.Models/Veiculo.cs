using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Models
{
    public class Veiculo
    {
        public int VeiculoId { get; set; }
        public string Placa { get; set; }
        public int MarcaId { get; set; }
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public string Cor { get; set; }
        public int TipoVeiculoId { get; set; }
        public int CombustivelId { get; set; }
    }
}
