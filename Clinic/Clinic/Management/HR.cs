using System;
using System.Collections.Generic;
using System.Linq;
using Clinic.Models;
using Clinic.Models.Enums;

namespace Clinic.Management
{
    public class HR : IHR
    {
        private Dictionary<uint, Doctor> _doctors;
        public event EventHandler<DoctorEventArgs> OnDoctorChanged;

        public HR(Dictionary<uint, Doctor> doctors)
        {
            _doctors = doctors;
        }

        public void AddDoctor(Doctor doctor)
        {
            _doctors.Add(doctor.Id, doctor);
            var doctorEventArgs = new DoctorEventArgs()
            {
                Doctor = doctor,
                DoctorEventType = DoctorEventType.Add
            };
            if (OnDoctorChanged != null) OnDoctorChanged.Invoke(this, doctorEventArgs);
        }

        public bool EditDoctor(uint doctorID, Doctor doctor)
        {
            if (_doctors.ContainsKey(doctorID))
            {
                _doctors[doctorID] = doctor;
                var doctorEventArgs = new DoctorEventArgs()
                {
                    Doctor = doctor,
                    DoctorEventType = DoctorEventType.Edit
                };

                OnDoctorChanged?.Invoke(this, doctorEventArgs);
                return true;
            }
            return false;
        }

        public Doctor GetDoctorById(uint doctorId)
        {
            Doctor doctor;
            if (_doctors.TryGetValue(doctorId, out doctor))
            {
                return doctor;
            }
            return null;
        }

        public Doctor GetDoctorByName(string doctorName)
        {
            foreach (var doctor in _doctors.Values)
            {
                if (doctor.Name == doctorName) return doctor;
            }
            return null;
        }

        public List<Doctor> GetDoctorsBySpec(Speciality specialty)
        {
            return _doctors.Values.Where(doctor => doctor.Specialities.Contains(specialty)).ToList();
        }

        public bool RemoveDoctor(uint doctorId)
        {
            Doctor doctor;
            if (_doctors.TryGetValue(doctorId, out doctor))
            {
                _doctors.Remove(doctorId);
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
