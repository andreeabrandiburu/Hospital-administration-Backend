using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace ProiectFinal.Services
{
    public interface IPacientService
    {
        List<Pacient> GetPacients();

        void Create(Pacient pacient);

        void Update(Pacient pacient);

        void Delete(int id);
    }
}
