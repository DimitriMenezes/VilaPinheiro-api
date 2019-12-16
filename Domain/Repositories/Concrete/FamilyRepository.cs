using Domain.Entities;
using Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories.Concrete
{
    public class FamilyRepository : BaseRepository<Family> , IFamilyRepository
    {
    }
}
