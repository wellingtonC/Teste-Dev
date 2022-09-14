using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Model
{
    public class CreditoDTO
    {
        public bool StatusCredito { get; set; }
        public double ValorTotal { get; set; }
        public double ValorJuros { get; set; }
        public string Motivo { get; set; }
    }
}
