using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateMedDB.Business;
using UltimateMedDB.Business.dsUltimateMedDBTableAdapters;


namespace UltimateMedDBConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing my application");

            /*
            //Instantiate the Doctor List
            DoctorList doctors = new DoctorList();

            //Add new doctor
            doctors.AddDoctor("Eli Watson", "Intensive Care");

            //Instantiate the Records list which contains all patients and their Billing, Doctor, & Labs data
            Console.WriteLine("Testing Billing Class\n\n");
            List<Patient> PatientsFromDatabase = PatientRecords.GetAllPatients();
            Patient firstPatient = PatientsFromDatabase[0];
            Console.WriteLine("First Patient" + firstPatient.Name);

            //Add Bill by first looking up the Patient ID from Patient Table.
            //Then, insert the Bill and SQL query returns the Scope_Identity
            //Third, insert the Pid and ScopeID into Patient_Bill Connector table to make
            //connection between the Patient and Bill.

            Bill testBill = new Bill
            {
                BillTotal = 155,
                PatientType = "outpatient",
                InsuranceCarrier = "Cigna"
            };

            BillTableAdapter taBill = new BillTableAdapter();
            int pid = (int)taBill.GetPatientPID("John Smith");
            BillTableAdapter taNewBill = new BillTableAdapter();
            var ScopeID = taNewBill.AddBillReturnScopeID(testBill.PatientType, testBill.MedicineCharge, testBill.DoctorCharge,
                                            testBill.RoomCharge, testBill.OperationCharge, testBill.NursingCharge,
                                            testBill.LabCharge, testBill.BillTotal, testBill.InsuranceCarrier);
            taNewBill.InsertBillByPidScopeID(pid, Convert.ToInt32(ScopeID));



            //Adds New Room to HospitalRooms List and also to the database
            Console.WriteLine("Testing Rooms Class\n\n");
            Rooms newRoom = new Rooms();
            newRoom.AddNewRoom(304, "OR", "Available");

            //Get all Rooms from Database
            List<Room> RoomsFromDatabase = Rooms.GetAllRooms();
            Console.WriteLine("First Room Number in Table: " + RoomsFromDatabase[0].Number);

            */
            /*
            Console.WriteLine("Testing AllLabs Class\n\n");
            //Add Labs
            AllLabs labs = new AllLabs();
            Lab lab = new Lab
            {
                Amount = 55,
                Category = "Blood Test",
                Date = new DateTime(2019, 12, 14),
                Doc_id = 1,
                PatientType = "OutPatient",
                Weight = 135
            };
            labs.AddLab(lab, "Jenny Stone");

            Lab lab1 = new Lab
            {
                Amount = 33,
                Category = "Urine",
                Date = new DateTime(2019, 12, 11),
                Doc_id = 3,
                PatientType = "OutPatient",
                Weight = 210
            };
            labs.AddLab(lab1, "John Smith");

            List<Lab> LabsFromDatabase = AllLabs.GetAllLabs();
            Console.WriteLine("First Lab Amount: " + LabsFromDatabase[0].Amount);
            */
            //List<Bill> allBills = Bill.GetAllBillingRecords();
            //List<Patient> allpatients = Patient.GetAllPatients();
            List<Bill> billsByPid = Bill.GetBillsByPid(3);
 

            Console.WriteLine("Goodbye");
            Console.ReadKey();

        }
    }
}
