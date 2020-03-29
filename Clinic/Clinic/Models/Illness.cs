using System.Collections.Generic;
using Clinic.Management;

namespace Clinic.Models
{
   public class Illness
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public List<string> Symptoms { get; set; }

        public Illness(string name, List<string> symptoms)
        {
            Id = GenerateIds.GetNextIllnessId();
            Name = name;
            Symptoms = symptoms;
        }
    }
}
