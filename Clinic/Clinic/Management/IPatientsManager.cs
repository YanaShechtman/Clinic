using System.Collections.Generic;

namespace Clinic.Management
{
     public interface IPatientsManager
     {
         Dictionary<uint, Patient> Patients { get; set; }
         void AddPatient(Patient patient);
         bool RemovePatient(uint patientId);
         bool EditPatient(uint patientId, Patient patient);
    }
}
