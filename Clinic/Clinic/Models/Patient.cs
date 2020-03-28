using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Enums;

namespace Clinic
{
    public class Patient : Person
    {
        public uint InsuranceNumber { get; set; }
        public Management ClinicManagement { get; set; }
        public IList<Illness> Illnesses { get; set; }
        public Severity Severity { get; set; }
        public IList<Allergies> Allergies { get; set; }
        public List<Visit> Visits { get; set; }

        public Patient(uint id, string name, Sex sex, uint age, DateTime birthDate,Management clinicManagement, List<Allergies> allergies, IList<Illness> illnesses, Severity severity)
            : base(id, name, sex, age, birthDate)
        {
            Illnesses = illnesses;
            ClinicManagement = clinicManagement;
            Allergies = allergies;
            InsuranceNumber = GenerateIds.GetNextPatientId();
        }

        public Patient(uint id, string name, Sex sex, uint age, DateTime birthDate, Management clinicManagement
            , IList<Allergies> allergies)
          : base(id, name, sex, age, birthDate)
        {
            ClinicManagement = clinicManagement ;
            Illnesses = new List<Illness>();
            Severity = Severity.None;
            Allergies = allergies;
        }

        public void ScheduleVisitByDoctorName(string doctorName, IList<Illness> illnesses)
        {
            var doctor = ClinicManagement.GetDoctorByName(doctorName);
            var visit = ClinicManagement.ScheduleVisit(doctor.Id,this,illnesses);
            Visits.Add(visit);
        }
        public void ScheduleVisitByDoctorSpec(Speciality speciality, IList<Illness> illnesses)
        {
            var doctors = ClinicManagement.GetDoctorsBySpeciality(speciality);
            var randomDoctor = doctors.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var visit = ClinicManagement.ScheduleVisit(randomDoctor.Id,this,illnesses);
            Visits.Add(visit);
        }
    }
}