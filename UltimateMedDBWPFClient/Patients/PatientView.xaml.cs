using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UltimateMedDBWPFClient.Patients
{
    /// <summary>
    /// Interaction logic for PatientView.xaml
    /// </summary>
    public partial class PatientView : UserControl
    {
        public PatientView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Use implicit casting with caution
            UltimateMedDBWPFClient.Billing.PatientBillingViewModel currentViewModel =
                (UltimateMedDBWPFClient.Billing.PatientBillingViewModel)DataContext;

            UltimateMedDB.Business.Patient newPatient = currentViewModel.NewPatient;

            currentViewModel.NewPatient.SaveNewPatient(newPatient.Name, newPatient.Gender, newPatient.Age,
                newPatient.Weight, newPatient.Address, newPatient.Phone, newPatient.Disease, newPatient.Doc_Id);

            BindingOperations.GetBindingExpressionBase(cboAllPatients, ComboBox.ItemsSourceProperty).UpdateTarget();

            //Clear fields once New Patient has been saved
            NewPatientAddress.Text = String.Empty;
            NewPatientWeight.Text = String.Empty;
            NewPatientName.Text = String.Empty;
            NewPatientAge.Text = String.Empty;
            NewPatientDocId.Text = String.Empty;
            NewPatientDisease.Text = String.Empty;
            NewPatientGender.Text = String.Empty;
            NewPatientPhone.Text = String.Empty;

            MessageBox.Show("Patient Has Been Successfully Saved.");
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DgPatientBills.Items.Refresh();

            DataGrid dependentGrid = DgPatientBills;
            dependentGrid.Items.Refresh();
        }

        //This Event is triggered when the user selects a specific patient.  The subsequent field "Patient's Bills"
        //is then updated with Bills that are assigned to the Patient.
        private void CboAllPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Obtain the view model dataContext
            UltimateMedDBWPFClient.Billing.PatientBillingViewModel currentViewModel =
                (UltimateMedDBWPFClient.Billing.PatientBillingViewModel)DataContext;

            //Get the new List<Bill> object from the current view model
            var a = currentViewModel.BillsByPid;

            //Assign the ItemsSource of the Patient's Bill DataGrid to the newly obtained object
            DgPatientBills.ItemsSource = a;
            DgPatientBills.Items.Refresh();
        }

        private void DataGrid_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            DgPatientBills.Items.Refresh();
        }
    }
}
