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
                decimal DividoPorDois = Numeracao / (decimal)2;
                decimal DividoPorTres = Numeracao / (decimal)3;
                decimal DividoPorQuatro = Numeracao / (decimal)4;
                decimal DividoPorCinco = Numeracao / (decimal)5;
                decimal DividoPorSeis = Numeracao / (decimal)6;
                decimal DividoPorSete = Numeracao / (decimal)7;
                decimal DividoPorOito = Numeracao / (decimal)8;
                decimal DividoPorNove = Numeracao / (decimal)9;
                decimal DividoPorDez = Numeracao / (decimal)10;

                if (DividoPorDois.ToString().Split(',').Length != 1 &&
                    DividoPorTres.ToString().Split(',').Length != 1 &&
                    DividoPorQuatro.ToString().Split(',').Length != 1 &&
                    DividoPorCinco.ToString().Split(',').Length != 1 &&
                    DividoPorSeis.ToString().Split(',').Length != 1 &&
                    DividoPorSete.ToString().Split(',').Length != 1 &&
                    DividoPorOito.ToString().Split(',').Length != 1 &&
                    DividoPorNove.ToString().Split(',').Length != 1 &&
                    DividoPorDez.ToString().Split(',').Length != 1
                    )
                {
                    NumerosPrimos.Add(Numeracao);
                    Primo = true;
                }
                else if (Numeracao == 2 || Numeracao == 3 || Numeracao == 5 || Numeracao == 7)
                {
                    NumerosPrimos.Add(Numeracao);
                    Primo = true;
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
