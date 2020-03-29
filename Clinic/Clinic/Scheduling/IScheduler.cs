using System.Collections.Generic;
using Clinic.Models;

namespace Clinic.Scheduling
{
    public interface IScheduler
    {
        Dictionary<uint,List<Visit>> Visits { get; set; }
        List<Doctor> Doctors { get; set; }
        Visit CreateVisit(uint doctorId, Patient patient, IList<Illness> illnesses);
        void CancelVisit(uint visitId);
        void OnDoctorAdded(Doctor doctor);
        void OnDoctorRemoved(Doctor doctor);
        void OnDoctorEdited(Doctor doctor);
    }
}
