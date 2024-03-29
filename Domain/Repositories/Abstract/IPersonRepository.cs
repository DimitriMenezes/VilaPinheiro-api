﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories.Abstract
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Person GetByCpf(string cpf);
    }
}
