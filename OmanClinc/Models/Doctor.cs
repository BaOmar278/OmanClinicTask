using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmanClinc.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string DoctorPhone { get; set; }
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
