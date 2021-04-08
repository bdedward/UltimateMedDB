using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateMedDB.Business
{
    public class Bill
    {
        public string PatientType{ get; set; }
        public decimal MedicineCharge { get; set; }
        public decimal DoctorCharge { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal OperationCharge { get; set; }
        public decimal NursingCharge { get; set; }
        public string InsuranceCarrier { get; set; }
        public decimal LabCharge { get; set; }
        public decimal BillTotal { get; set; }

    }
}
