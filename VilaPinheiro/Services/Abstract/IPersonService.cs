using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilaPinheiro.Models;

namespace VilaPinheiro.Services.Abstract
{
    public interface IPersonService
    {
        DTOPerson ObterPessoa(string cpf);
        IQueryable<Person> ObterProximosAniversarios(int qtdDays);
    }
}
