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

        public static List<Bill> GetBillsByPid(int pid)
        {
            List<Bill> PatientBills = new List<Bill>();
            Patient_BillTableAdapter taBills = new Patient_BillTableAdapter();            
            var dtBills = taBills.GetBillingbyPID(pid);

            foreach (dsUltimateMedDB.Patient_BillRow billingRow in dtBills)
            {
            /*    Bill currentBill = new Bill
                {
                    PatientType = billingRow.PatientType,
                    DoctorCharge = billingRow.DoctorCharge,
                    LabCharge = billingRow.LabCharge,
                    OperationCharge = billingRow.OperationCharge,
                    RoomCharge = billingRow.RoomCharge,
                    MedicineCharge = billingRow.MedicineCharge,
                    NursingCharge = billingRow.NursingCharge,
                    InsuranceCarrier = billingRow.InsuranceCarrier
                }; */
                //PatientBills.Add(currentBill);
            }
            return PatientBills;
        }

        public void AssignNewBill(Bill newBill, string Name)
        {
            BillTableAdapter taBill = new BillTableAdapter();
            int pid = (int)taBill.GetPatientPID("John Smith");
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
            Bill newBill = new Bill
            {
                PatientType = patientType,
                InsuranceCarrier = insuranceCarrier,
                DoctorCharge = doctorCharge,
                LabCharge = labCharge,
                OperationCharge = operationCharge,
                RoomCharge = roomCharge,
                MedicineCharge = medicineCharge,
                NursingCharge = nursingCharge
            };

            decimal total = doctorCharge + labCharge + operationCharge + nursingCharge + medicineCharge + roomCharge;
            newBill.BillTotal = total;

            Bills.Add(newBill);
        }
        public List<Bill> Bills { get; set; }
    }
}
