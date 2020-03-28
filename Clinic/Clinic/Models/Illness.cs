using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
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
