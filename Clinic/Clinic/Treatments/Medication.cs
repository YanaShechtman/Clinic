using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using Clinic.Enums;

namespace Clinic.Treatments
{
    public class Medication : ITreatment
    {
        public string Name { get; set; }
        public uint Id { get; }
        public TreatmentFrequency Frequency { get; set; }
        public string Comment { get; set; }
        public IList<Allergies> NotForAllergies { get; set; }
        public IList<Illness> NotBackgroundDiseases { get; set; }

        public Medication(string name, TreatmentFrequency frequency, string comment, IList<Allergies> notForAllergies, IList<Illness> notBackgroundDiseases)
        {
            Name = name;
            Id = GenerateIds.GetNextMedicationId();
            Frequency = frequency;
            Comment = comment;
            NotForAllergies = notForAllergies;
            NotBackgroundDiseases = notBackgroundDiseases;
        }
        public Medication()
        {
            Id = GenerateIds.GetNextMedicationId();
        }

        public bool IsRelevant(Patient patient)
        {
            if (patient.Allergies.Intersect(NotForAllergies).Any() ||
                patient.Illnesses.Intersect(NotBackgroundDiseases).Any())
                return false;
            return true;
        }

    }
}
