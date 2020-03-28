using System.Collections.Generic;

namespace Clinic.Management
{
    public class PatientsManager : IPatientsManager
    {
        public Dictionary<uint, Patient> Patients { get; set; }

        public void AddPatient(Patient patient)
        {
            Patients.Add(patient.Id,patient);
        }

        public bool RemovePatient(uint patientId)
        {
            if (Patients.ContainsKey(patientId))
            {
                Patients.Remove(patientId);
                return true;
            }

            return false;
        }

        public bool EditPatient(uint patientId, Patient patient)
        {
            if (Patients.ContainsKey(patientId))
            {
                Patients[patientId] = patient;
                return true;
            }

            return false;
        }

    }
}
