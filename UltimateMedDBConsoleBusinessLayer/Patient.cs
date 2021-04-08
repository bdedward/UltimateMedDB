using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateMedDB.Business.dsUltimateMedDBTableAdapters;

namespace UltimateMedDB.Business
{
    public class Patient
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Disease { get; set; }
        public string Doc_Id { get; set; }

    }
}
