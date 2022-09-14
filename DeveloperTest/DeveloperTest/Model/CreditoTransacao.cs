using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Model
{
    public class CreditoTransacao
    {
        public CreditoDTO ResultadoCredito(double valorCredito, string tipoCredito, int quantidadeParcelas, DateTime dataInicialVencimento) 
        {
            CreditoDTO resultado = new CreditoDTO();
            try
            {
                DateTime DataMinima = DateTime.Now.AddDays(15);
                DateTime DataMaxima = DateTime.Now.AddDays(40);
                
                double MaxCredito = 1000000.00;
                if (valorCredito > MaxCredito || dataInicialVencimento > DataMaxima || dataInicialVencimento < DataMinima
                    || quantidadeParcelas < 5 || quantidadeParcelas > 72)
                {
                    resultado.StatusCredito = false;
                    resultado.Motivo = "Proposta Negada: a proposta de crédito em questão não segue as normas exigidas para credito, favor rever a proposta";
                    resultado.ValorJuros = 0;
                    resultado.ValorTotal = 0;
                }
                else 
                {
                    switch (tipoCredito.ToLower()) 
                    {
                        case "crédito direto":
                            resultado.StatusCredito = true;
                            resultado.Motivo = "Aprovada Crédito Direto";
                            resultado.ValorJuros = valorCredito * 0.02;
                            resultado.ValorTotal = valorCredito * 1.02;
                            break;

                        case "crédito consignado":
                            resultado.StatusCredito = true;
                            resultado.Motivo = "Aprovada Crédito Consignado";
                            resultado.ValorJuros = valorCredito * 0.01;
                            resultado.ValorTotal = valorCredito * 1.01;
                            break;

                        case "crédito pessoa jurídica":
                            if (valorCredito >= 15000.00)
                            {
                                resultado.StatusCredito = true;
                                resultado.Motivo = "Aprovada Crédito Pessoa Jurídica";
                                resultado.ValorJuros = valorCredito * 0.05;
                                resultado.ValorTotal = valorCredito * 1.05;
                                break;
                            }
                            else 
                            {
                                resultado.StatusCredito = false;
                                resultado.Motivo = "Negado Crédito Pessoa Jurídica por ser menor do que 15MIL";
                                resultado.ValorJuros = 0;
                                resultado.ValorTotal = 0;
                                break;
                            }

                        case "crédito pessoa física":
                            resultado.StatusCredito = true;
                            resultado.Motivo = "Aprovada Crédito Pessoa Física";
                            resultado.ValorJuros = valorCredito * 0.03;
                            resultado.ValorTotal = valorCredito * 1.03;
                            break;

                        case "crédito imobiliário":
                            resultado.StatusCredito = true;
                            resultado.Motivo = "Aprovada Crédito Imobiliário";
                            resultado.ValorJuros = valorCredito * 0.09;
                            resultado.ValorTotal = valorCredito * 1.09;
                            break;

                        default:
                            resultado.StatusCredito = false;
                            resultado.Motivo = "Negado  Crédito Imobiliário";
                            resultado.ValorTotal = 0;
                            resultado.ValorJuros = 0;
                            break;

                    }      
                }
                return resultado;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}
