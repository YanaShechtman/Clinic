using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
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
