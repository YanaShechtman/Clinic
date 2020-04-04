using System;
using System.Collections.Generic;
using System.Linq;
using Clinic.Management;
using Clinic.Treatments;
using log4net;

namespace Clinic.Models
{
   public class Visit
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public uint Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Finished { get; set; }
        public IList<Illness> Illnesses { get; set; }

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

        public void ExecuteVisit()
        {
            _log.Debug($"Start Visit: {Id}");
            var prescription = Doctor.GiveTreatment(Patient, Illnesses);
            prescription.VisitId = Id;
            Patient.Prescriptions.Add(prescription);
            LogVisit(prescription);
            Finished = true;
            _log.Debug( $"Finish Visit: {Id}");
        }

        private void LogVisit(Prescription prescription)
        {
            var medications = prescription.MedicationsAmount.ToDictionary(pair => pair.Key.Name, pair => pair.Value);
            _log.Info(
                $"In visit_id: {Id} The doctor_name: {Doctor.Name} doctor_id: {Doctor.Id} treated patient_name: {Patient.Name} patient_id: {Patient.Id} and gave prescription_id: {prescription.Id}");
            foreach (var medication in medications.Keys)
            {
                _log.Info(
                    $"visit_id: {Id} prescription_id: {prescription.Id} given medication_name: {medication} medication_amount: {medications[medication]}");
            }
        }
    }
}
