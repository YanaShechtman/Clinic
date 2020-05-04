using System.Collections.Generic;

namespace Clinic.Treatments
{
    public interface IPharmacy
    {
        IDictionary<uint, uint> MedicationsInStock { get; set; }
        IList<Medication> Medications { get; set; }
        void AddMedication(Medication medication, uint unitsInStock);
        bool RemoveMedication(uint medicationId);
        bool EditMedication(uint medicationId, Medication newMedication);
        bool EditMedicationStock(uint medicationId, uint unitsInStock);
        uint CheckUnitsInStock(uint medicationId);
        List<Medication> GiveMedications(Prescription prescription);

    }
}
