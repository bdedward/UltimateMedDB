using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateMedDB.Business.dsUltimateMedDBTableAdapters;

namespace UltimateMedDB.Business
{
    public class PatientRecords
    {
        public PatientRecords()
        {
            Patients = new List<Patient>();
        }
        public void SaveNewPatient(string Name, string Gender,
                        int Age, int Weight, string Address,
                        string Phone, string Disease, string Doctor)
        {
            PatientTableAdapter taPatient = new PatientTableAdapter();
            taPatient.AddNewPatient(Name, Gender, Age, Weight, Address, Phone, Disease, Doctor);
        }
        public static List<Patient> GetAllPatients()
        {
            PatientTableAdapter taPatient = new PatientTableAdapter();
            var dtMenu = taPatient.GetData();
            List<Patient> allPatients = new List<Patient>();

            foreach (dsUltimateMedDB.PatientRow patientRow in dtMenu.Rows)
            {
                Patient currentPatient = new Patient();
                PatientRecords record = new PatientRecords();
                record.AddPatient(currentPatient, patientRow.Name, patientRow.Gender, patientRow.Age, patientRow.Weight,
                            patientRow.Address, patientRow.Phone, patientRow.Disease, patientRow.Doc_Id);                
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
                allPatients.Add(currentPatient);
            }
            return allPatients;
        }


        public void AddPatient(Patient currentPatient, string Name, string Gender,
                        int Age, int Weight, string Address,
                        string Phone, string Disease, string Doctor)
        {
            Patient patient = new Patient();
            patient.Name = Name;
            patient.Gender = Gender;
            patient.Age = Age;
            patient.Weight = Weight;
            patient.Address = Address;
            patient.Phone = Phone;
            patient.Disease = Disease;
            patient.Doc_Id = Doctor;
            Patients.Add(patient);
        }
        public List<Patient> Patients;
    }
}
