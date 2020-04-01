using System.Collections.Generic;
using Clinic.Models;

namespace Clinic.Management
{
    public interface IPatientsManager
    {
        void AddPatient(Patient patient);
        bool RemovePatient(uint patientId);
        bool EditPatient(uint patientId, Patient patient);
    }
}