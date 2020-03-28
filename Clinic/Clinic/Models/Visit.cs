using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Treatments;

namespace Clinic
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
            Treatments = new List<ITreatment>();
            Finished = false;
        }
        public uint Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Finished { get; set; }
        public IList<Illness> Illnesses { get; set; }
        public  IList<ITreatment> Treatments { get; set; }
        public void ExecuteVisit()
        {
           Treatments = Doctor.GiveTreatment(Patient, Illnesses);
           Finished = true;
        }
    }
}
