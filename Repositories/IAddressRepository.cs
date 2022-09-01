using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Entities;
using WebProject.Models;

namespace ProiectFinal.Repositories
{
    public interface IAddressRepository
    {
        void Create(AddressEntity addressEntity);
        void Update(AddressEntity addressEntity);
        void Delete(AddressEntity addressEntity);

        IQueryable<AddressEntity> GetAddresses();
    }
}
