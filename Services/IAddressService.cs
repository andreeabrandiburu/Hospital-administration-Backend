using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace ProiectFinal.Services
{
    public interface IAddressService
    {
        List<Address> GetAddresses();

        void Create(Address address);

        void Update(Address address);

        void Delete(int id);
    }
}
