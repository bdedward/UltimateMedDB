using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateMedDB.Business
{
    public class Lab
    {
        public int Weight { get; set; }
        public int Doc_id { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string PatientType { get; set; }
        public decimal Amount { get; set; }
    }
}
