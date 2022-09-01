using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebProject.Models;

namespace ProiectFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private static List<Doctor> doctors = new List<Doctor>
        {
                new Doctor {Id=1, LastName="Doctor1", FirstName="Doctor1", PacientIds= Enumerable.Range(5, 10).ToList() },
                new Doctor {Id=2, LastName="Doctor2", FirstName="Doctor2", PacientIds= Enumerable.Range(1, 5).ToList() }
                
        };

        [HttpGet]
        public List<Doctor> GetDoctors()
        {
            return doctors;
        }

        [HttpGet("{Id}")]
        public Doctor GetByDoctorId(int Id)
        {
            return doctors
                .FirstOrDefault(pacient => pacient.Id == Id);
        }

        [HttpDelete("{Id}")]
        public void DeleteById(int Id)
        {
            List<Doctor> availablePacients = doctors.FindAll(Pacient => !(Pacient.Id == Id));
            doctors = availablePacients;
        }

        [HttpPut]
        public Doctor UpdateDoctor([FromBody] Doctor doctor)
        {
            Doctor doctorUpdated = doctors
            .FindLast(currentPacient => currentPacient.Id == doctor.Id);
            doctorUpdated.LastName = doctor.LastName;
            doctorUpdated.FirstName = doctor.FirstName;
            doctorUpdated.PacientIds = doctor.PacientIds;
          

            return doctorUpdated;
        }

        [HttpPost]
        public void AddDoctor([FromBody] Doctor pacient)
        {
            doctors.Add(pacient);
        }

    }
}
