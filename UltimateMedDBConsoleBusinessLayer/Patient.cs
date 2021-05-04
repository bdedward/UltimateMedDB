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
        public Patient(){
            Patients = new List<Patient>();
        }

        public void SaveNewPatient(string Name, string Gender,
                        int Age, int Weight, string Address,
                        string Phone, string Disease, string Doctor)
        {
            PatientTableAdapter taPatient = new PatientTableAdapter();
            if(Name != null)
                taPatient.AddNewPatient(Name, Gender, Age, Weight, Address, Phone, Disease, Doctor);
        }


        public static List<Patient> GetAllPatients()
        {
            PatientTableAdapter taPatient = new PatientTableAdapter();
            PatientTableAdapter taPatients = new PatientTableAdapter();
            var dtMenu = taPatient.GetData();
            List<Patient> allPatients = new List<Patient>();
            

            foreach (dsUltimateMedDB.PatientRow patientRow in dtMenu.Rows)
            {
                Patient currentPatient = new Patient();
                currentPatient.Pid = patientRow.Id;
                currentPatient.Address = patientRow.Address;
                currentPatient.Age = patientRow.Age;
                currentPatient.Name = patientRow.Name;
                currentPatient.Gender = patientRow.Gender;
                currentPatient.Age = patientRow.Age;
                currentPatient.Weight = patientRow.Weight;
                currentPatient.Address = patientRow.Address;
                currentPatient.Phone = patientRow.Phone;
                currentPatient.Disease = patientRow.Disease;
                currentPatient.Doc_Id = patientRow.Doc_Id;
                currentPatient.AddPatient(currentPatient);
                allPatients.Add(currentPatient);                
            }
            return allPatients;
        }

        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
            InstanceCount += 1;
        }

        public static int InstanceCount { get; set; }

        public List<Patient> Patients { get; set; }

        public int Pid { get; set; }
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
