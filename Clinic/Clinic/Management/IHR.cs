using System;
using System.Collections.Generic;
using Clinic.Models;
using Clinic.Models.Enums;

namespace Clinic.Management
{
    public interface IHR
    {
        event EventHandler<DoctorEventArgs> OnDoctorChanged;
        void AddDoctor(Doctor doctor);
        bool RemoveDoctor(uint doctorId);
        bool EditDoctor(uint doctorId, Doctor doctor);
        Doctor GetDoctorByName(string doctorName);
        Doctor GetDoctorById(uint doctorId);
        List<Doctor> GetDoctorsBySpec(Speciality specialty);
    }
}