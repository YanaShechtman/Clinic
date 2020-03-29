using System;
using System.Collections.Generic;
using Clinic.Management;
using Medications;

namespace Clinic.Models
{
   public class Visit
    {
        public Visit(Patient patient, Doctor doctor, DateTime startTime, DateTime endTime, IList<Illness> illnesses)
        {
            Id = GenerateIds.GetNextVisitId();
            Patient = patient;
            Doctor = doctor;
            StartTime = startTime;
            EndTime = endTime;
            Illnesses = illnesses;
            Finished = false;
        }
        public uint Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Finished { get; set; }
        public IList<Illness> Illnesses { get; set; }

        public void ExecuteVisit()
        {
            var prescription = Doctor.GiveTreatment(Patient, Illnesses);
            prescription.VisitId = Id;
            Patient.Prescriptions.Add(prescription);
            Finished = true;
        }
    }
}
