using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilaPinheiro.Services.Abstract
{
    public interface IPersonService
    {
        Person ObterPessoa(string cpf);
        void ObterProximosAniversarios();
    }
}
