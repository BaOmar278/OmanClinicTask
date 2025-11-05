using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmanClinc.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public string PatientPhone { get; set; }

        public Patient(int id, string fullName, string nationalId, string phone)
        {
            PatientId = id;
            FullName = fullName;
            NationalId = nationalId;
            PatientPhone = phone;
        }
    }
}
