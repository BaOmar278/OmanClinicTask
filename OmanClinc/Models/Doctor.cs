using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmanClinc.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string DoctorPhone { get; set; }
        [ForeignKey("Specialty")]
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }

        public Doctor(int id, string fullName, string phone, Specialty specialty)
        {
            DoctorId = id;
            FullName = fullName;
            DoctorPhone = phone;
            Specialty = specialty;
        }
    }
}
