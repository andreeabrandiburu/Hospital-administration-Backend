using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Entities;

namespace ProiectFinal.Repositories
{
    public interface IPacientRepository
    {
        void Create(PacientEntity pacientEntity);
        void Update(PacientEntity pacientEntity);
        void Delete(PacientEntity pacientEntity);

        IQueryable<PacientEntity> GetPacients();
    }
}
