using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmanClinc.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }

        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
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
