using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UltimateMedDB.Business;

namespace UltimateMedDBWPFClient.Labs
{
    public class LabViewModel : BindableBase
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
            }
        }

        public List<Lab> PatientLabs
        {
            get
            {
                return Lab.GetAllLabs();
            }
        }

        public List<Lab> LabsByPatient
        {
            get
            {
                if (SelectedPatient.Name != null)
                    return Lab.LabsByPatient(SelectedPatient.Name);
                return null;
            }
        }

        private Lab _newLab = new Lab();
        public Lab NewLab
        {
            get
            {
                return _newLab;
            }
            set
            {
                _newLab = value;
            }

        }

    }
}
