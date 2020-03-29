namespace Clinic.Management
{
    public static class GenerateIds
    {
        private static uint _patientId = 100000;
        private static uint _doctorId = 1000;
        private static uint _visitId = 0;
        private static uint _medicationId = 0;
        private static uint _illnessId = 0;
        private static uint _prescriptionId = 0;

        public static uint GetNextPatientId()
        {
            return _patientId++;
        }
        public static uint GetNextDoctorId()
        {
            return _doctorId++;
        }
        public static uint GetNextMedicationId()
        {
            return _medicationId++;
        }
        public static uint GetNextIllnessId()
        {
            return _illnessId++;
        }
        public static uint GetNextVisitId()
        {
            return _visitId++;
        }
        public static uint GetNextPrescriptionId()
        {
            return _prescriptionId++;
        }
    }
}
