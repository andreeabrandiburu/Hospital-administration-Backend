using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Entities;

namespace ProiectFinal.Repositories
{
    public interface IDoctorRepository
    {
        void Create(DoctorEntity doctorEntity);
        void Update(DoctorEntity doctorEntity);
        void Delete(DoctorEntity doctorEntity);

        IQueryable<DoctorEntity> GetDoctors();
    }
}
