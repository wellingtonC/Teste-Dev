using DeveloperTest.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DeveloperTest.Controllers
{
    public class CreditoController : Controller
    {
        [HttpGet]
        [Route("Consulta de credito")]
        [AllowAnonymous]
        public ActionResult<CreditoDTO> Get(double valorCredito, string tipoCredito, int quantidadeParcelas, string dataInicialVencimento)
        {
            try
            {
                DateTime DataRecebida = Convert.ToDateTime(dataInicialVencimento);
                CreditoTransacao liberacaocredito = new CreditoTransacao();
                CreditoDTO credito = new CreditoDTO();
                credito = liberacaocredito.ResultadoCredito(valorCredito, tipoCredito, quantidadeParcelas, DataRecebida);
                if (credito != null)
                {
                    return credito;
                }
                else
                {
                    return BadRequest("falha ao executar o recurso de credito");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
