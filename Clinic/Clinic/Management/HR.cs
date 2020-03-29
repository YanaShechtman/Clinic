using System;
using System.Collections.Generic;
using System.Linq;
using Clinic.Models;
using Clinic.Models.Enums;

namespace Clinic.Management
{
    public class HR : IHR
    {
        public Dictionary<uint, Doctor> Doctors { get; set; }
        public event EventHandler<DoctorEventArgs> OnDoctorChanged;

        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor.Id, doctor);
            DoctorEventArgs doctorEventArgs = new DoctorEventArgs()
            {
                Doctor = doctor,
                DoctorEventType = DoctorEventType.Add
            };
            OnDoctorChanged.Invoke(this,doctorEventArgs);
        }

        public bool EditDoctor(uint doctorID,Doctor doctor)
        {
            if(Doctors.ContainsKey(doctorID))
            {
                Doctors[doctorID] = doctor;
                var doctorEventArgs = new DoctorEventArgs()
                {
                    Doctor = doctor,
                    DoctorEventType = DoctorEventType.Edit
                };
                OnDoctorChanged?.Invoke(this, doctorEventArgs);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Doctor GetDoctorById(uint doctorID)
        {
            Doctor doctor;
            if(Doctors.TryGetValue(doctorID, out doctor))
            {
                return doctor;
            }
            else
            {
                return null;
            }
        }

        public Doctor GetDoctorByName(string doctorName)
        {
            return Doctors.Values.FirstOrDefault(doctor => doctor.Name == doctorName);
        }

        public List<Doctor> GetDoctorsBySpec(Speciality specialty)
        {
            return Doctors.Values.Where(doctor => doctor.Specialities.Contains(specialty)).ToList();
        }

        public bool RemoveDoctor(uint doctorID)
        {
            Doctor doctor;
            if (Doctors.TryGetValue(doctorID,out doctor))
            {
                Doctors.Remove(doctorID);
                var doctorEventArgs = new DoctorEventArgs()
                {
                    Doctor = doctor,
                    DoctorEventType = DoctorEventType.Remove
                };
                OnDoctorChanged?.Invoke(this, doctorEventArgs);
                return true;
            }

            return false;
        }
    }
}
