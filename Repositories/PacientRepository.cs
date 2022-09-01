using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebProject.Entities;

namespace ProiectFinal.Repositories
{
    public class PacientRepository : IPacientRepository
    {
        private ProiectFinalWebContext db;

       public PacientRepository(ProiectFinalWebContext db)
        {
            this.db = db;
        }
        public void Create(PacientEntity pacientEntity)
        {
            db.Pacient.Add(pacientEntity);
            db.SaveChanges();
        }

        public void Delete(PacientEntity pacientEntity)
        {
            db.Pacient.Remove(pacientEntity);
            db.SaveChanges();
        }

        public IQueryable<PacientEntity> GetPacients()
        {
            return db.Pacient.Include(pacient => pacient.Doctor).Include(pacient => pacient.Address);
        }

        public void Update(PacientEntity pacientEntity)
        {
            db.Pacient.Update(pacientEntity);
            db.SaveChanges();
        }
    }
}
