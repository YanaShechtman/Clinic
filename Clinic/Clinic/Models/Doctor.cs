using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Enums;
using Clinic.Treatments;
namespace Clinic
{
    public class Doctor : Person
    {
        public List<Speciality> Specialities { get; set; }

        public Doctor(uint id, string name, Sex sex, uint age, DateTime birthDate, List<Speciality> specialities)
        : base(id, name, sex, age, birthDate)
        {
        }

        public List<ITreatment> GiveTreatment(Patient patient, IList<Illness> illnesses)
        {
            var treatments = new List<ITreatment>();
            foreach (var illness in illnesses)
            {
                var treatmentsInGeneral = CommonKnowledge.GetTreatmentsByIllnessId(illness.Id);
                treatments.AddRange(treatmentsInGeneral);
            }
            return treatments.Where(treatment => treatment.IsRelevant(patient)).ToList();
        }
    }
}
