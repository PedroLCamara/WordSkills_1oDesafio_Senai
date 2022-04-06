using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSTowers.Interfaces;

namespace WSTowers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RegioesController : ControllerBase
    {
        private readonly IRegiaoRepository ctx;

        public RegioesController(IRegiaoRepository repo)
        {
            ctx = repo;
        }

        [HttpGet]
        public IActionResult ListarVendas()
        {
            return Ok(ctx.ListarVendas());
        }
    }
}
