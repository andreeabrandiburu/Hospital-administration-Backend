using ProiectFinal.Repositories;
using System.Collections.Generic;
using WebProject.Entities;
using WebProject.Models;

using System.Linq;
namespace ProiectFinal.Services
{
    public class AddressService : IAddressService
    {

        private readonly IAddressRepository addressRepository;
       
        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        
        public void Create(Address address)
        {
            var newAddress = new AddressEntity
            {
                Id = address.Id,
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber

            };

            addressRepository.Create(newAddress);
        }

        public void Delete(int id)
        {
            Address address = GetAddresses().FindLast(address => address.Id == id);
            var newAdressEntity = new AddressEntity
            {
                Id = address.Id,
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber
            };
            addressRepository.Delete(newAdressEntity);
        }

        public List<Address> GetAddresses()
        {
            List<AddressEntity> addressEntities = addressRepository.GetAddresses()

                .ToList()
                ;

            List<Address> addresses = new List<Address>();
            foreach (var addressEntity in addressEntities)
            {
                var newAddress = new Address
                {
                    Id = addressEntity.Id,
                    StreetNumber = addressEntity.StreetNumber,
                    StreetName = addressEntity.StreetName
                };

                addresses.Add(newAddress);
            }
                return addresses;
        }

        public void Update(Address address)
        {
            var addressEntity = new AddressEntity()
            {
                Id = address.Id,
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber
            };
            addressRepository.Update(addressEntity);
        }
    }
}
