using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WSTowers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AlgoritmosController : ControllerBase
    {
        [HttpGet("NumerosPrimos/{n}")]
        public IActionResult NumerosPrimos(int n)
        {
            decimal Numeracao = 2;
            List<decimal> NumerosPrimos = new List<decimal>();
            for (int i = 0; i < n;)
            {
                bool Primo = false;
                bool DivisaoSucedida = false;
                if (Numeracao == 2)
                {
                    NumerosPrimos.Add(Numeracao);
                    Primo = true;
                }
                else
                {
                    foreach(decimal numero in NumerosPrimos)
                    {
                        decimal numeroDivisao = Numeracao / numero;
                        int numeroDivisaoDecimal = numeroDivisao.ToString().Split(',').Length;
                        if (numeroDivisaoDecimal == 1)
                        {
                            DivisaoSucedida = true;
                        }
                    }
                    if (DivisaoSucedida == false)
                    {
                        NumerosPrimos.Add(Numeracao);
                        Primo = true;
                    }
                }
                if (Primo)
                {
                    i++;
                }
                Numeracao++;
            }
            return Ok(NumerosPrimos);
        }
    }
}
