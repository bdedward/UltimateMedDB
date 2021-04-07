using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateMedDB.Business.dsUltimateMedDBTableAdapters;

namespace UltimateMedDB.Business
{
    public class Billing
    {
        public Billing(){
            Bills = new List<Bill>();
        }

        public static void AssignBill(string Name)
        {
            BillTableAdapter taBill = new BillTableAdapter();
            var pid = taBill.GetPatientPID(Name);
            BillTableAdapter taNewBill = new BillTableAdapter();
            //taNewBill.AddNewBill(pid);
        }



        public static List<Bill> GetAllBillingRecords()
        {
            BillTableAdapter taBilling = new BillTableAdapter();
            var dtBilling = taBilling.GetData();
            List<Bill> allBilling = new List<Bill>();

            foreach (dsUltimateMedDB.BillRow billingRow in dtBilling.Rows)
            {
                Bill currentBill = new Bill();
                Billing newBill = new Billing();
                newBill.AddBill(billingRow.PatientType, billingRow.DoctorCharge, billingRow.LabCharge, billingRow.OperationCharge,
                            billingRow.RoomCharge, billingRow.MedicineCharge, billingRow.NursingCharge, billingRow.InsuranceCarrier);
                currentBill.PatientType = billingRow.PatientType;
                currentBill.DoctorCharge = billingRow.DoctorCharge;
                currentBill.LabCharge = billingRow.LabCharge;
                currentBill.OperationCharge = billingRow.OperationCharge;
                currentBill.RoomCharge = billingRow.RoomCharge;
                currentBill.MedicineCharge = billingRow.MedicineCharge;
                currentBill.NursingCharge = billingRow.NursingCharge;
                currentBill.InsuranceCarrier = billingRow.InsuranceCarrier;       
                allBilling.Add(currentBill);
            }
            return allBilling;
        }

        public void AddBill(string patientType, decimal doctorCharge, decimal labCharge,
                            decimal operationCharge, decimal roomCharge, decimal medicineCharge,
                            decimal nursingCharge, string insuranceCarrier)
        {
            Bill newBill = new Bill();
            newBill.PatientType = patientType;
            newBill.InsuranceCarrier = insuranceCarrier;
            newBill.DoctorCharge = doctorCharge;
            newBill.LabCharge = labCharge;
            newBill.OperationCharge = operationCharge;
            newBill.RoomCharge = roomCharge;
            newBill.MedicineCharge = medicineCharge;
            newBill.NursingCharge = nursingCharge;

            decimal total = doctorCharge + labCharge + operationCharge + nursingCharge + medicineCharge + roomCharge;
            newBill.BillTotal = total;

            Bills.Add(newBill);
        }



        public List<Bill> Bills;

    }
}
