﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WSTowers.Domains;
using WSTowers.ViewModels;

namespace WSTowers.Interfaces
{
    public interface IRegiaoRepository
    {
        List<Regiao> ListarVendas();
    }
}
