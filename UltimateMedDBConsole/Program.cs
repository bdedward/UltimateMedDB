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
            //Instantiate the Doctor List
            DoctorList doctors = new DoctorList();

            //Add new doctor
            doctors.AddDoctor("Eli Watson", "Intensive Care");

            //Instantiate the Records list which contains all patients and their Billing, Doctor, & Labs data
            List<Patient> PatientsFromDatabase = PatientRecords.GetAllPatients();
            Patient firstPatient = PatientsFromDatabase[0];
            Console.WriteLine("First Patient" + firstPatient.Name);

            //Add Bill
            BillTableAdapter taBill = new BillTableAdapter();
            var pid = taBill.GetPatientPID("John Smith");
            Console.WriteLine("PID Of John Smith: " + pid);

            //Testing Labs
            Lab lab = new Lab();
            lab.Amount = 55;
            lab.Category = "Blood Test";
            lab.Date = new DateTime(2019, 12, 14);
            lab.Doc_Id = "Mitchell";

            Console.WriteLine("Testing my application");
            Console.ReadKey();

        }
    }
}
