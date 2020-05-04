using System;
using Clinic.Models.Enums;

namespace Clinic.Models
{
    public abstract class Person
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public uint Age { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(uint id, string name, Sex sex, uint age, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Age = age;
            BirthDate = birthDate;
        }
    }
}
