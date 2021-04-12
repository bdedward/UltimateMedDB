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
                return Patient.GetAllPatients();
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
                //RaisePropertyChanged();
            }
        }

        private Patient _newPatient = new Patient();
        public Patient NewPatient
        {
            get
            {
                return _newPatient;
            }
            set
            {
                _newPatient = value;
            }
        }



        public List<Bill> AllBills
        {
            get
            {
                return Bill.GetAllBillingRecords();
            }
        }

        public List<Bill> BillsByPid
        {
            get
            {
                return Bill.GetBillsByPid(SelectedPatient.Pid);
            }
        }

        private Bill _selectedBill = new Bill();
        public Bill SelectedBill
        {
            get
            {
                return _selectedBill;
            }
            set
            {
                _selectedBill = value;
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
