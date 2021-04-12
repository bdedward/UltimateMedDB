using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateMedDB.Business.dsUltimateMedDBTableAdapters;

namespace UltimateMedDB.Business
{
    public class Bill
    {
        public Bill()
        {
            Bills = new List<Bill>();
        }

        public static List<Bill> GetBillsByPid(int pid)
        {
            List<Bill> PatientBills = new List<Bill>();
            BillTableAdapter taBills = new BillTableAdapter();
            var dtBills = taBills.GetBillingByPID(pid);

            foreach (dsUltimateMedDB.BillRow billingRow in dtBills)
            {
                Bill currentBill = new Bill
                {
                    PatientType = billingRow.PatientType,
                    DoctorCharge = billingRow.DoctorCharge,
                    LabCharge = billingRow.LabCharge,
                    OperationCharge = billingRow.OperationCharge,
                    RoomCharge = billingRow.RoomCharge,
                    MedicineCharge = billingRow.MedicineCharge,
                    NursingCharge = billingRow.NursingCharge,
                    InsuranceCarrier = billingRow.InsuranceCarrier
                };
                PatientBills.Add(currentBill);
            }
            return PatientBills;
        }

        public void AssignNewBill(Bill newBill, string Name)
        {
            PatientTableAdapter taBill = new PatientTableAdapter();
            int pid = (int)taBill.GetPatientID("John Smith");
            BillTableAdapter taNewBill = new BillTableAdapter();
            //Returns the Bill_id so that we may assign it in the Patient_Bill Connector Table.
            var ScopeID = taNewBill.AddBillReturnScopeID(newBill.PatientType, newBill.MedicineCharge, newBill.DoctorCharge,
                                            newBill.RoomCharge, newBill.OperationCharge, newBill.NursingCharge,
                                            newBill.LabCharge, newBill.BillTotal, newBill.InsuranceCarrier);
            //Add row to Patient_Bill table using PID and Bill_id
            taNewBill.InsertBillByPidScopeID(pid, Convert.ToInt32(ScopeID));

            //Add Bill to our Bills list
            Bills.Add(newBill);
        }

        public static List<Bill> GetAllBillingRecords()
        {
            BillTableAdapter taBilling = new BillTableAdapter();
            var dtBilling = taBilling.GetData();
            List<Bill> allBilling = new List<Bill>();

            foreach (dsUltimateMedDB.BillRow billingRow in dtBilling.Rows)
            {
                Bill currentBill = new Bill();
                currentBill.PatientType = billingRow.PatientType;
                currentBill.DoctorCharge = billingRow.DoctorCharge;
                currentBill.LabCharge = billingRow.LabCharge;
                currentBill.OperationCharge = billingRow.OperationCharge;
                currentBill.RoomCharge = billingRow.RoomCharge;
                currentBill.MedicineCharge = billingRow.MedicineCharge;
                currentBill.NursingCharge = billingRow.NursingCharge;
                currentBill.InsuranceCarrier = billingRow.InsuranceCarrier;
                decimal total = currentBill.DoctorCharge + currentBill.LabCharge + currentBill.OperationCharge + currentBill.NursingCharge 
                                + currentBill.MedicineCharge + currentBill.RoomCharge;
                currentBill.BillTotal = total;
                currentBill.AddBill(currentBill);
                allBilling.Add(currentBill);
            }
            return allBilling;
        }

        public void AddBill(Bill bill)
        { 
            Bills.Add(bill);
        }

        public List<Bill> Bills { get; set; }
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
