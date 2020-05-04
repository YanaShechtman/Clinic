using Clinic.Models;

namespace Clinic.Treatments
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