using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Clinic.Sceduling;

namespace Clinic
{
    public class Scheduler : IScheduler
    {
        public Scheduler()
        {
           _visitDuration = int.Parse(ConfigurationManager.AppSettings["VisitDurationInMin"]);
        }
        public Dictionary<uint, List<Visit>> Visits { get; set; }
        public List<Doctor> Doctors { get; set; }
        private readonly int _visitDuration;
        public void CancelVisit()
        {
            throw new NotImplementedException();
        }

        public Visit CreateVisit(uint doctorId, Patient patient, IList<Illness> illnesses)
        {
            List<Visit> visits;
            if (Visits.TryGetValue(doctorId, out visits))
            {
                var maxVisit = visits[0];
                foreach (var visit in visits.Where(visit => visit.EndTime > maxVisit.EndTime))
                {
                    maxVisit = visit;
                }

                var doctor = Doctors.FirstOrDefault(doctor1 => doctor1.Id == doctorId);
                var newVisit = new Visit(patient, doctor, maxVisit.EndTime, maxVisit.EndTime.AddMinutes(_visitDuration),illnesses);
                visits.Add(newVisit);
                return newVisit;
            }
            else return null;
        }

        public void EditVisit()
        {
            throw new NotImplementedException();
        }
        
        public void OnDoctorAdded(Doctor doctor)
        {
            Visits.Add(doctor.Id, new List<Visit>());
            Doctors.Add(doctor);
        }
        public void OnDoctorRemoved(Doctor doctor)
        {
            Visits.Remove(doctor.Id);
            var index = FindDoctorById(doctor.Id);
            Doctors.RemoveAt(index);
        }

        public void OnDoctorEdited(Doctor doctor)
        {
            var index = FindDoctorById(doctor.Id);
            Doctors[index] = doctor;
        }

        private int FindDoctorById(uint doctorId)
        {
            return Doctors.FindIndex(doctor => doctor.Id == doctorId);
        }
    }
}

