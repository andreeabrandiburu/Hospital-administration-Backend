using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Entities;

namespace ProiectFinal.Repositories
{
    public class AddressRepository: IAddressRepository
    {
        private ProiectFinalWebContext db;

        public AddressRepository(ProiectFinalWebContext db)
        {
            this.db = db;
        }

        public void Create(AddressEntity addressEntity)
        {
            db.Address.Add(addressEntity);

            db.SaveChanges();
        }

        public void Delete(AddressEntity addressEntity)
        {
            db.Address.Remove(addressEntity);

            db.SaveChanges();
        }

        public IQueryable<AddressEntity> GetAddresses()
        {
            return db.Address.Include(x => x.Pacient);
        }

        public void Update(AddressEntity addressEntity)
        {
            db.Address.Update(addressEntity);
            db.SaveChanges();
        }
    }
}
