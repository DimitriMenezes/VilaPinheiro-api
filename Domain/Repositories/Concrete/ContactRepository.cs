using Domain.Context;
using Domain.Entities;
using Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories.Concrete
{
    public class ContactRepository : BaseRepository<Contact> , IContactRepository
    {
        public ContactRepository()
        { 
            
        }
    }
}
