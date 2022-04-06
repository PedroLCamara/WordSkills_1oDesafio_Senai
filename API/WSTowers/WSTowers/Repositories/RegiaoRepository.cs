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

        public async Task<List<RegiaoViewModel>> ListarVendas()
        {
            List<RegiaoViewModel> listaRetorno = new List<RegiaoViewModel>();
            //List<Regiao> listaRetorno = ctx.Regiaos.Select(r => new Regiao()
            //{
            //    Regiao1 = r.Regiao1,
            //    Estados = r.Estados.Select(e => new Estado()
            //    {
            //        Cidades = e.Cidades.Select(c => new Cidade()
            //        {
            //            Participantes = c.Participantes.Select(p => new Participante()
            //            {
            //                Venda = p.Venda.Select(e => new Venda()
            //                {
            //                    ProdutoNavigation = new Produto
            //                    {
            //                        Valor = e.ProdutoNavigation.Valor
            //                    }
            //                }).ToList(),
            //            }).ToList(),
            //        }).ToList(),
            //    }).ToList(),
            //}).ToList();
            //List<Regiao> listaRetorno = ctx.Regiaos.Include(r => r.Estados).ThenInclude(e => e.Cidades).ThenInclude(c => c.Participantes).ThenInclude(p => p.Venda).ThenInclude(v => v.Produto).ToList();
            List<Regiao> listaRegioes = await ctx.Regiaos.Include(r => r.Estados).ThenInclude(e => e.Cidades).AsNoTracking().ToListAsync();
            List<Participante> listaParticipantes = await ctx.Participantes.AsNoTracking().ToListAsync();
            List<Venda> listaVenda = await ctx.Vendas.AsNoTracking().ToListAsync();
            List<Produto> listaProduto = await ctx.Produtos.AsNoTracking().ToListAsync();
            
            foreach (Regiao regiao in listaRegioes)
            {
                RegiaoViewModel NovaRegiao = new RegiaoViewModel();
                NovaRegiao.Nome = regiao.Regiao1;
                List<Cidade> cidadesRegiao = new List<Cidade>();
                foreach (Estado estado in regiao.Estados)
                {
                    foreach (Cidade cidade in estado.Cidades)
                    {
                        cidadesRegiao.Add(cidade);
                    }
                }
                int vendas = 0;
                int? totalVendido = 0;
                //List <Participante> ParticipantesVendaValida = new List<Participante>();
                foreach (Participante participante in listaParticipantes)
                {
                    if (cidadesRegiao.FirstOrDefault(c => c.Id == participante.Cidade) != null)
                    {
                        foreach (Venda venda in listaVenda)
                        {
                            if (venda.Participante == participante.Id)
                            {
                                vendas++;
                                foreach (Produto produto in listaProduto)
                                {
                                    if (venda.Produto == produto.Id)
                                    {
                                        totalVendido = totalVendido + produto.Valor;
                                    }
                                }
                            }
                        }
                    }
                }

                NovaRegiao.ValorVendido = totalVendido;
                NovaRegiao.Vendas = vendas;

                listaRetorno.Add(NovaRegiao);
            }

            return listaRetorno;
        }
    }
}
