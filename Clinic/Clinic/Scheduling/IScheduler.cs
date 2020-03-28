using System.Collections.Generic;

namespace Clinic.Sceduling
{
    public interface IScheduler
    {
        Dictionary<uint,List<Visit>> Visits { get; set; }
        List<Doctor> Doctors { get; set; }
        Visit CreateVisit(uint doctorId, Patient patient, IList<Illness> illnesses);
        void EditVisit();
        void CancelVisit();
        void OnDoctorAdded(Doctor doctor);
        void OnDoctorRemoved(Doctor doctor);
        void OnDoctorEdited(Doctor doctor);
    }
}
