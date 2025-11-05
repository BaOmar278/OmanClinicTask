using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmanClinc.Models
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; }

        public Specialty(int id, string name)
        {
            SpecialtyId = id;
            SpecialtyName = name;
        }
    }
}
