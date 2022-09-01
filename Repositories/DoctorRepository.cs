using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Entities;

namespace ProiectFinal.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private ProiectFinalWebContext db;
        public DoctorRepository(ProiectFinalWebContext db)
        {
            this.db = db;
        }
        public void Create(DoctorEntity doctorEntity)
        {
            db.Doctor.Add(doctorEntity);

            db.SaveChanges();
        }

        public void Delete(DoctorEntity doctorEntity)
        {
            db.Doctor.Remove(doctorEntity);
            db.SaveChanges();
        }

        public IQueryable<DoctorEntity> GetDoctors()
        {
            return db.Doctor;
        }

        public void Update(DoctorEntity doctorEntity)
        {
            db.Update(doctorEntity);

            db.SaveChanges();
        }
    }
}
