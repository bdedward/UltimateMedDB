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
        public string Gender;
        public int Age;
        public int Weight;
        public string Address;
        public string Phone;
        public string Disease;
        public string Doc_Id;

    }
}
