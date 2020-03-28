using System;

namespace Clinic.Management
{
    public class DoctorEventArgs : EventArgs
    {
        public Doctor Doctor { get; set; }
        public DoctorEventType DoctorEventType { get; set; }
    }
}
