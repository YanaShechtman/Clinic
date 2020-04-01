using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Treatments
{
    public class TreatmentFrequency
    {
        public uint Times { get; set; }
        public Range Range { get; set; }

        public TreatmentFrequency(uint times, Range range)
        {
            Times = times;
            Range = range;
        }
    }
}
