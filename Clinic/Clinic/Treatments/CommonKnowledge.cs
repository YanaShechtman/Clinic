using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Treatments
{
    public static class CommonKnowledge
    {
        public static Dictionary<uint, List<ITreatment>> IllnessToTreatment { set; get; }

        public static List<ITreatment> GetTreatmentsByIllnessId(uint illnessID)
        {
            List<ITreatment> treatmentsByIllnessId;
            if (IllnessToTreatment.TryGetValue(illnessID, out treatmentsByIllnessId))
            {
                return treatmentsByIllnessId;
            }
            else
            {
                return null;
            }
        }

        public static bool AddTreatmentToIllness(uint illnessId, List<ITreatment> treatments)
        {
            List<ITreatment> treatmentsByIllnessId;
            if (IllnessToTreatment.TryGetValue(illnessId, out treatmentsByIllnessId))
            {
                treatmentsByIllnessId.AddRange(treatments);
                IllnessToTreatment[illnessId] = treatmentsByIllnessId;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool AddIllness(uint illnessId)
        {
            if (IllnessToTreatment.ContainsKey(illnessId))
            {
                return false;
            }
            else
            {
                IllnessToTreatment.Add(illnessId, new List<ITreatment>());
                return true;
            }
        }
    }
}
