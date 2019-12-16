using Domain.Entities;
using Domain.Repositories.Abstract;
using Domain.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilaPinheiro.Models;
using VilaPinheiro.Services.Abstract;

namespace VilaPinheiro.Services.Concrete
{
    public class HouseService : IHouseService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IHouseRepository _houseRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IFamilyRepository _familyRepository;

        public HouseService(IPersonRepository personRepository, 
            IHouseRepository houseRepository, 
            IContactRepository contactRepository,
            IFamilyRepository familyRepository
            )
        {
            _personRepository = personRepository;
            _houseRepository = houseRepository;
            _contactRepository = contactRepository;
            _familyRepository = familyRepository;
        }

        public void InsertHouse(DTOHouse dto)
        {
            var house = new House
            {
                Number = dto.Number,
                Phone = dto.Phone
            };
            _houseRepository.Insert(house);

            if(dto.Residents != null && dto.Residents.Count > 0)
            {
                foreach (var resident in dto.Residents)
                {
                    var person = new Person()
                    {
                        Cpf = resident.Cpf,
                        DateOfBirth = resident.DateOfBirth,
                        Name = resident.Name,
                        Nickname = resident.Nickname
                    };
                    _personRepository.Insert(person);

                    if (resident.Contact != null)
                    {
                        var contact = new Contact
                        {
                            PersonId = person.Id,
                            Email = resident.Contact.Email,
                            Cellphone1 = resident.Contact.Cellphone1,
                            Cellphone2 = resident.Contact.Cellphone2
                        };
                        _contactRepository.Insert(contact);
                    }

                    var family = new Family()
                    {
                        HouseId = house.Id,
                        PersonId = person.Id,
                        FamilyRelationshipId = (int) resident.FamilyRelationshipId
                    };
                    _familyRepository.Insert(family);
                }
            }          
        }
    }
}
