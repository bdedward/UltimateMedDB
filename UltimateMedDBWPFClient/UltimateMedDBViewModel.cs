using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateMedDB.Business;

namespace UltimateMedDB.WPFClient
{
    public class UltimateMedDBViewModel
    {
 
        public List<Patient> AllPatients
        {
            get
            {
                return PatientRecords.GetAllPatients();
            }
        }
        private Patient _selectedPatient = new Patient();
        public Patient SelectedPatient
        {
            get
            {
                return _selectedPatient;
            }
            set
            {
                _selectedPatient = value;
            }
        }


        public List<Bill> AllBills
        {
            get
            {
                return Billing.GetAllBillingRecords();
            }
        }

        public List<Lab> PatientLabs
        {
            get
            {
                return AllLabs.GetAllLabs();
            }
        }


    }
}
