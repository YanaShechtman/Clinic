using System.Collections.Generic;

namespace Clinic.Treatments
{
    public class CommonKnowledge
    {
        private Dictionary<uint, List<IMedication>> _illnessToTreatment { set; get; }

        public CommonKnowledge(Dictionary<uint, List<IMedication>> illnessToTreatment)
        {
            _illnessToTreatment = illnessToTreatment;
        }

        public List<IMedication> GetTreatmentsByIllnessId(uint illnessID)
        {
            List<IMedication> treatmentsByIllnessId;
            if (_illnessToTreatment.TryGetValue(illnessID, out treatmentsByIllnessId))
            {
                return treatmentsByIllnessId;
            }

            return null;
        }

        public bool AddTreatmentToIllness(uint illnessId, List<IMedication> treatments)
        {
            List<IMedication> treatmentsByIllnessId;
            if (_illnessToTreatment != null && _illnessToTreatment.TryGetValue(illnessId, out treatmentsByIllnessId))
            {
                treatmentsByIllnessId.AddRange(treatments);
                _illnessToTreatment[illnessId] = treatmentsByIllnessId;
                return true;
            }

            return false;
        }
        public bool AddIllness(uint illnessId)
        {
            if (_illnessToTreatment.ContainsKey(illnessId))
            {
                return false;
            }
            else
            {
                _illnessToTreatment.Add(illnessId, new List<IMedication>());
                return true;
            }
        }
    }
}