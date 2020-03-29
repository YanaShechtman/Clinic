using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Management;

namespace Medications
{
    public class Prescription
    {
        public uint Id { get; set; }
        public uint VisitId { get; set; }
        public uint PatientId { get; set; }
        public uint DoctorId { get; set; }
        public Dictionary<IMedication, uint> MedicationsAmount{ get; set; }
        public bool IsTaken;

        public Prescription(uint patientId, uint doctorId, Dictionary<IMedication, uint> medicationsAmount)
        {
            Id = GenerateIds.GetNextPrescriptionId();
            PatientId = patientId;
            DoctorId = doctorId;
            MedicationsAmount = medicationsAmount;
            IsTaken = false;
        }
    }
}
