using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Enums;

namespace Clinic.Treatments
{
   public interface ITreatment
    {
        string Name { get; set; }
        TreatmentFrequency Frequency { get; set; }
        string Comment { get; set; }
        bool IsRelevant(Patient patient);
    }
}
