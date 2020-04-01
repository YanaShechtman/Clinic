using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinic.Treatments
{
    public class Pharmacy : IPharmacy
    {
        public IDictionary<uint, uint> MedicationsInStock { get; set; }
        public IList<Medication> Medications { get; set; }

        public Pharmacy(IDictionary<uint, uint> medicationsInStock, IList<Medication> medications)
        {
            MedicationsInStock = medicationsInStock;
            Medications = medications;
            if (!ValidateMedicationList())
            {
                throw new ArgumentException("The ids of the dictionary and list must be equal");
            }
        }

        private bool ValidateMedicationList()
        {
            var medicationsIdsFromDict = MedicationsInStock.Keys.ToList();
            var medicationsIdsFromList = Medications.Select(medication => medication.Id).ToList();
            return medicationsIdsFromList.SequenceEqual(medicationsIdsFromDict);
        }

        public Pharmacy()
        {
            MedicationsInStock = new Dictionary<uint, uint>();
            Medications = new List<Medication>();
        }

        public void AddMedication(Medication medication, uint unitsInStock)
        {
            MedicationsInStock.Add(medication.Id, unitsInStock);
            Medications.Add(medication);
        }

        public bool RemoveMedication(uint medicationId)
        {
            if (MedicationsInStock.ContainsKey(medicationId))
            {
                MedicationsInStock.Remove(medicationId);
                Medications.ToList().RemoveAll(medication => medication.Id == medicationId);
                return true;
            }

            return false;
        }

        public bool EditMedication(uint medicationId, Medication newMedication)
        {
            foreach (var medication in Medications)
            {
                if (medication.Id == medicationId)
                {
                    var index = Medications.IndexOf(medication);
                    Medications[index] = newMedication;
                    return true;
                }
            }

            return false;
        }

        public bool EditMedicationStock(uint medicationId, uint unitsInStock)
        {
            if (MedicationsInStock.ContainsKey(medicationId))
            {
                MedicationsInStock[medicationId] = unitsInStock;
                return true;
            }

            return false;
        }

        public uint CheckUnitsInStock(uint medicationId)
        {
            uint units;
            if (MedicationsInStock.TryGetValue(medicationId, out units))
            {
                return units;
            }

            return 0;
        }

        public List<Medication> GiveMedications(Prescription prescription)
        {
            var medications = new List<Medication>();
            foreach (var medication in prescription.MedicationsAmount)
            {
                medications.AddRange(GiveMedication(medication.Key.Id, medication.Value));
            }

            return medications;
        }

        private List<Medication> GiveMedication(uint medicationId, uint units)
        {
            if (MedicationsInStock.ContainsKey(medicationId))
            {
                if (MedicationsInStock[medicationId] > units)
                {
                    var medications = new List<Medication>();
                    var medication = Medications.FirstOrDefault(medication1 => medication1.Id == medicationId);
                    for (var i = 0; i < units; i++)
                    {
                        medications.Add(medication);
                    }

                    MedicationsInStock[medicationId] -= units;
                    return medications;
                }
                else
                {
                    throw new ArgumentException("Entered more units then units in stock");
                }
            }
            else
                throw new ArgumentException("medication Id does not exist");
        }
    }

}