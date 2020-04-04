using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using Clinic.Models.Enums;
using Clinic.Treatments;
using log4net;

namespace Clinic.Models
{
    public class Doctor : Person
    {
        public List<Speciality> Specialities { get; set; }
        public CommonKnowledge CommonKnowledge { get; set; }
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Doctor(uint id, string name, Sex sex, uint age, DateTime birthDate, List<Speciality> specialities)
            : base(id, name, sex, age, birthDate)
        {
        }

        public Prescription GiveTreatment(Patient patient, IList<Illness> illnesses)
        {
            var treatments = new List<IMedication>();
            foreach (var illness in illnesses)
            {
                var treatmentsInGeneral = CommonKnowledge.GetTreatmentsByIllnessId(illness.Id);
                treatments.AddRange(treatmentsInGeneral);
            }
            var medicationsToGive = treatments.Where(treatment => treatment.IsRelevant(patient)).ToList();
            var medications = medicationsToGive.ToDictionary<IMedication, IMedication, uint>
                (medication => medication, medication => 1);
            return new Prescription(patient.Id, Id, medications);
        }
    }
}