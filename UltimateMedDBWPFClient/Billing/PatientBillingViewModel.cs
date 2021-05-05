using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UltimateMedDB.Business;

namespace UltimateMedDBWPFClient.Billing
{
    public class PatientBillingViewModel : BindableBase
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
                //PropertyChanged(this, new PropertyChangedEventArgs("SelectedPatient"));
                //OnPropertyChanged("SelectedPatient");
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

        private Bill _newBill = new Bill();
        public Bill NewBill
        {
            get
            {
                return _newBill;
            }
            set
            {
                _newBill = value;
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



    }
}