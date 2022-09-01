using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace ProiectFinal.Services
{
    public interface IDoctorService
    {
        List<Doctor> GetDoctors();

        void Create(Doctor doctor);

        void Update(Doctor doctor);

    }
}
