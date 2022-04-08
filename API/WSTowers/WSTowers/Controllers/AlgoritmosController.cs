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

        [HttpPost("DezNumerosSequenciados/")]
        public IActionResult DezNumerosSequenciados(int[] listaNumeros)
        {
            if (listaNumeros.Length != 10)
            {
                return BadRequest(new { message = "A quantidade de números deve ser igual a 10!" });
            }
            bool PA = true;
            bool PG = true;
            int PosicaoNumeroPA = 1;
            int PosicaoNumeroPG = 1;
            int RazaoPA = listaNumeros[1] - listaNumeros[0];
            int RazaoPG = listaNumeros[1] / listaNumeros[0];

            //Logica verificacao PA
            foreach (int numero in listaNumeros)
            {
                if (numero != (listaNumeros[0] + (PosicaoNumeroPA -1)*RazaoPA))
                {
                    PA = false;
                    break;
                }
                PosicaoNumeroPA++;
            }

            //Logica Verificacao PG
            foreach (int numero in listaNumeros)
            {
                int RazaoElevada = RazaoPG;
                if ((PosicaoNumeroPG - 1) == 0)
                {
                    RazaoElevada = 1;
                }
                else
                {
                    for (int i = 1; i < (PosicaoNumeroPG - 1); i++)
                    {
                            int RazaoElevadaAnterior = RazaoElevada;
                            RazaoElevada = RazaoElevadaAnterior * RazaoPG;
                    }
                }

                if (numero != (listaNumeros[0] * RazaoElevada))
                {
                    PG = false;
                    break;
                }
                PosicaoNumeroPG++;
            }

            if (PA == true && PG == true)
            {
                return Ok("É uma P.A e uma P.G!");
            }
            if (PA == true)
            {
                return Ok("É uma P.A!");
            }
            else if (PG == true)
            {
                return Ok("É uma P.G!");
            }
            else
            {
                return Ok("Definitivamente são números!");
            }
        }
    }
}
