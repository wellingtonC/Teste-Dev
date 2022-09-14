using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Model.DTO
{
    public class FinanciamentoDTO
    {
        public string CPF { get; set; }
        public string TipoFinanciamento { get; set; }
        public double ValorTotal { get; set; }
        public DateTime DataVencimento { get; set; }

    }
}
