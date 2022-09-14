using System;

namespace DeveloperTest.Model.DTO
{
    public class CreditoDTO 
    {
        public String Nome { get; set; }
        public string CPF { get; set; }
        public string UF { get; set; }
        public int Celular { get; set; }

        public FinanciamentoDTO Financiamento { get; set; }

    }
}
