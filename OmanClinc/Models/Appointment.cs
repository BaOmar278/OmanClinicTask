using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmanClinc.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        public Appointment(int id, DateTime date, Patient patient, Doctor doctor)
        {
            AppointmentId = id;
            AppointmentDate = date;
            Patient = patient;
            Doctor = doctor;
        }
    }
}
