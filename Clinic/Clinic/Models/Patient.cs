using System;
using System.Collections.Generic;
using System.Linq;
using Clinic.Management;
using Clinic.Models.Enums;
using Clinic.Treatments;

namespace Clinic.Models
{
    public class Patient : Person
    {
        public uint InsuranceNumber { get; set; }
        public Management.Management ClinicManagement { get; set; }
        public IList<Illness> Illnesses { get; set; }
        public Severity Severity { get; set; }
        public IList<Allergies> Allergies { get; set; }
        public List<Visit> Visits { get; set; }
        public List<Prescription> Prescriptions { get; set; }

        public Patient(uint id, string name, Sex sex, uint age, DateTime birthDate, Management.Management clinicManagement, List<Allergies> allergies, IList<Illness> illnesses, Severity severity)
            : base(id, name, sex, age, birthDate)
        {
            Illnesses = illnesses;
            ClinicManagement = clinicManagement;
            Allergies = allergies;
            InsuranceNumber = GenerateIds.GetNextPatientId();
        }

        public Patient(uint id, string name, Sex sex, uint age, DateTime birthDate, Management.Management clinicManagement
            , IList<Allergies> allergies)
          : base(id, name, sex, age, birthDate)
        {
            ClinicManagement = clinicManagement;
            Illnesses = new List<Illness>();
            Severity = Severity.None;
            Allergies = allergies;
            InsuranceNumber = GenerateIds.GetNextPatientId();
        }

        public void ScheduleVisitByDoctorName(string doctorName, IList<Illness> illnesses)
        {
            var doctor = ClinicManagement.GetDoctorByName(doctorName);
            var visit = ClinicManagement.ScheduleVisit(doctor.Id, this, illnesses);
            Visits.Add(visit);
        }
        public void ScheduleVisitByDoctorSpec(Speciality speciality, IList<Illness> illnesses)
        {
            var doctors = ClinicManagement.GetDoctorsBySpeciality(speciality);
            var randomDoctor = doctors.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var visit = ClinicManagement.ScheduleVisit(randomDoctor.Id, this, illnesses);
            Visits.Add(visit);
        }

        public void CancelVisit(uint visitId)
        {
            ClinicManagement.CancelVisit(visitId);
            Visits.RemoveAll((visit => visit.Id == visitId));
        }

        public List<Medication> TakePrescription(Prescription prescription)
        {
            if (CheckPrescription(prescription))
            {
                Prescriptions.Find(prescription1 => prescription1.Id == prescription.Id).IsTaken = true;
                return ClinicManagement.GivePatientPrescription(prescription);
            }
            else
            {
                throw new ArgumentException("The patient cannot take the prescription - the prescription has been delivered or does not exist");
            }
        }

        private bool CheckPrescription(Prescription prescription)
        {
            return Prescriptions != null && 
                   (Prescriptions.Any(patientPrescription => patientPrescription.Id == prescription.Id) 
                                             && (Prescriptions.Find(prescription1 => prescription1.Id == prescription.Id).IsTaken = false));
        }
    }
}