using System;
using System.Collections.Generic;
using Clinic.Models;
using Clinic.Models.Enums;
using Clinic.Scheduling;
using Medications;

namespace Clinic.Management
{
    public class Management : IDisposable
    {
        private readonly IHR _hr;
        private readonly IScheduler _scheduler;
        private readonly IPatientsManager _patientsManager;
        private readonly IPharmacy _pharmacy;

        public Management(IHR hr, IScheduler scheduler, IPatientsManager patientsManager, IPharmacy pharmacy)
        {
            _hr = hr;
            _scheduler = scheduler;
            _patientsManager = patientsManager;
            _pharmacy = pharmacy;
            _hr.OnDoctorChanged += OnDoctorChanged;
        }

        private void OnDoctorChanged(object sender, DoctorEventArgs e)
        {
            switch (e.DoctorEventType)
            {
                case DoctorEventType.Add:
                    _scheduler.OnDoctorAdded(e.Doctor);
                    break;
                case DoctorEventType.Remove:
                    _scheduler.OnDoctorRemoved(e.Doctor);
                    break;
                case DoctorEventType.Edit:
                    _scheduler.OnDoctorEdited(e.Doctor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Doctor GetDoctorByName(string doctorName)
        {
            return _hr.GetDoctorByName(doctorName);
        }

        public List<Doctor> GetDoctorsBySpeciality(Speciality doctorSpeciality)
        {
            return _hr.GetDoctorsBySpec(doctorSpeciality);
        }

        public Visit ScheduleVisit(uint doctorId, Patient patient, IList<Illness> illnesses)
        {
            return _scheduler.CreateVisit(doctorId, patient, illnesses);
        }

        public void CancelVisit(uint visitId)
        {
            _scheduler.CancelVisit(visitId);
        }

        public List<Medication> GivePatientPrescription(Prescription prescription)
        {
            return _pharmacy.GiveMedications(prescription);
        }

        public void Dispose()
        {
            _hr.OnDoctorChanged -= OnDoctorChanged;
        }
    }
}
