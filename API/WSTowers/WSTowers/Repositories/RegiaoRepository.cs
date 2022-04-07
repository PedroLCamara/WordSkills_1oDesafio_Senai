using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowers.Contexts;
using WSTowers.Domains;
using WSTowers.Interfaces;
using WSTowers.ViewModels;

namespace WSTowers.Repositories
{
    public class RegiaoRepository : IRegiaoRepository
    {
        private readonly WSTowersContext ctx;

        public RegiaoRepository(WSTowersContext appContext)
        {
            ctx = appContext;
        }

        public List<Regiao> ListarVendas()
        {
            return ctx.Regiaos.ToList();
        }
    }
}
