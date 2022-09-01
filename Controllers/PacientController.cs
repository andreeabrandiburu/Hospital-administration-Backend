using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebProject.Entities;

namespace ProiectFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientController : ControllerBase
    {
        private static AddressEntity add1 = new AddressEntity {
            Id = 1,
            StreetName = "Add1",
            StreetNumber = 1
        };

        private static AddressEntity add2 = new AddressEntity
        {
            Id = 1,
            StreetName = "Add2",
            StreetNumber = 2
        };
        private static List<PacientEntity> pacients = new List<PacientEntity>
        {
                new PacientEntity { Id=1, LastName="A", FirstName="B", Disease="C", Address=add1 },
                new PacientEntity { Id=2, LastName="B", FirstName="C", Disease="D", Address=add2 }
            };

        [HttpGet]
        public List<PacientEntity> GetPacients()
        {
            return pacients;
        }

        [HttpGet("{Id}")]
        public PacientEntity GetByPacientId(int Id)
        {
            return pacients
                .FirstOrDefault(pacient => pacient.Id == Id);

        }
        
        [HttpDelete("{Id}")]
        public void DeleteById(int Id)
        {
         
            List<PacientEntity> availablePacients = pacients.FindAll(Pacient => !(Pacient.Id == Id));
            pacients = availablePacients;
            
        }

        [HttpPut]
        public PacientEntity UpdatePacient([FromBody] PacientEntity pacient){
            PacientEntity pacientUpdated = pacients
            .FindLast(currentPacient => currentPacient.Id == pacient.Id);
            pacientUpdated.Address = pacient.Address;
            pacientUpdated.Disease = pacient.Disease;
            pacientUpdated.FirstName = pacient.FirstName;
            pacientUpdated.LastName = pacient.LastName;

            return pacientUpdated;
        }

        [HttpPost]
        public void AddPacient([FromBody] PacientEntity pacient)
        {
            pacients.Add(pacient);
        }

        [HttpGet("{FirstName}/{LastName}")]
        public List<PacientEntity> searchByName(string FirstName, string LastName)
        {
            return pacients
                .FindAll(pacient => pacient.FirstName == FirstName  && pacient.LastName == LastName);
        }
    }
}
