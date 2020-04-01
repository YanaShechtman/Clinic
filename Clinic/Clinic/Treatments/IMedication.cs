using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Models;

namespace Medications
{
    public interface IMedication
    {
        uint Id { get; }
        string Name { get; set; }
        TreatmentFrequency Frequency { get; set; }
        string Comment { get; set; }
        bool IsRelevant(Patient patient);

    }
}