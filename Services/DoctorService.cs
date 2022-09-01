using ProiectFinal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Entities;
using WebProject.Models;

namespace ProiectFinal.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IPacientRepository pacientRepository;

        public DoctorService(IDoctorRepository doctorRepository, IPacientRepository pacientRepository)
        {
            this.pacientRepository = pacientRepository;
            this.doctorRepository = doctorRepository;
        }
        public void Create(Doctor doctor)
        {
            List<PacientEntity> pacients = pacientRepository.GetPacients()
                .ToList().FindAll(pacient =>
                {

                    foreach (var pacientId in doctor.PacientIds)
                    {
                        if (pacient.Id == pacientId)
                        {
                            return true;
                        }
                    }

                    return false;
                }
                    ).ToList();

            DoctorEntity doctorEntity = new DoctorEntity
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Pacients = pacients
            };
            doctorRepository.Create(doctorEntity);
            
        }

        public List<Doctor> GetDoctors()
        {
          List<DoctorEntity> doctorsEntity =  doctorRepository.GetDoctors().ToList();
          List<Doctor> doctors = new List<Doctor>();

          List<int> pacientIds = new List<int>();
          
          foreach (var doctorEntity in doctorsEntity)
          {
               foreach(var pacientEntity in doctorEntity.Pacients)
                {
                    pacientIds.Add(pacientEntity.Id);
                }
                var doctor = new Doctor()
                {
                    Id =  doctorEntity.Id,
                    FirstName = doctorEntity.FirstName,
                    LastName = doctorEntity.LastName,
                    PacientIds =  pacientIds
    
                };

                doctors.Add(doctor);
          }
            return doctors;
        }

        public void Update(Doctor doctor)
        {
            List<PacientEntity> pacients = pacientRepository.GetPacients()
                .ToList().FindAll(pacient =>
                {

                    foreach (var pacientId in doctor.PacientIds)
                    {
                        if (pacient.Id == pacientId)
                        {
                            return true;
                        }
                    }

                    return false;
                }
                    ).ToList();

            DoctorEntity doctorEntity = new DoctorEntity()
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName
            };
            doctorRepository.Update(doctorEntity);
        }
    }
}
