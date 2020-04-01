using System.Collections.Generic;
using Medications;

namespace Clinic.Treatments
{
    public class CommonKnowledge
    {
        public static Dictionary<uint, List<IMedication>> IllnessToTreatment { set; get; }

        public static List<IMedication> GetTreatmentsByIllnessId(uint illnessID)
        {
            List<IMedication> treatmentsByIllnessId;
            if (IllnessToTreatment.TryGetValue(illnessID, out treatmentsByIllnessId))
            {
                return treatmentsByIllnessId;
            }

            return null;
        }

        public static bool AddTreatmentToIllness(uint illnessId, List<IMedication> treatments)
        {
            List<IMedication> treatmentsByIllnessId;
            if (IllnessToTreatment.TryGetValue(illnessId, out treatmentsByIllnessId))
            {
                treatmentsByIllnessId.AddRange(treatments);
                IllnessToTreatment[illnessId] = treatmentsByIllnessId;
                return true;
            }

            return false;
        }
        public static bool AddIllness(uint illnessId)
        {
            if (IllnessToTreatment.ContainsKey(illnessId))
            {
                return false;
            }
            else
            {
                IllnessToTreatment.Add(illnessId, new List<IMedication>());
                return true;
            }
        }
    }
}