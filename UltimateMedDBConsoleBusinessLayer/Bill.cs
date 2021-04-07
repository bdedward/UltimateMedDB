using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateMedDB.Business
{
    public class Bill
    {
        public string PatientType;
        public int Pid;
        public decimal MedicineCharge;
        public decimal DoctorCharge;
        public decimal RoomCharge;
        public decimal OperationCharge;
        public decimal NursingCharge;
        public string InsuranceCarrier;
        public decimal LabCharge;
        public decimal BillTotal;

    }
}
