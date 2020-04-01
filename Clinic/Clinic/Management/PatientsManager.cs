using System.Collections.Generic;
using Clinic.Models;

namespace Clinic.Management
{
    public class PatientsManager : IPatientsManager
    {
        private Dictionary<uint, Patient> _patients { get; set; }

        public void AddPatient(Patient patient)
        {
            _patients.Add(patient.Id, patient);
        }

        public bool RemovePatient(uint patientId)
        {
            return _patients.Remove(patientId);
        }

        public bool EditPatient(uint patientId, Patient patient)
        {
            if (_patients.ContainsKey(patientId))
            {
                _patients[patientId] = patient;
                return true;
            }

            return false;
        }

    }
}