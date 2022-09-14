using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Model.DTO
{
    public class ParcelaDTO 
    {
        public int IdFinanciamento { get; set; }
        public int NumeroParcela { get; set; }
        public double ValorParcela { get; set; }
        public DateTime DataVencimento{ get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
