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
using UltimateMedDB.Business;

namespace UltimateMedDBWPFClient.Billing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PatientBillingView : UserControl
    {
        public PatientBillingView()
        {
            InitializeComponent();
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

            if (currentViewModel != null)
            {
                //Get the new List<Bill> object from the current view model
                var a = currentViewModel.BillsByPid;

                //Assign the ItemsSource of the Patient's Bill DataGrid to the newly obtained object
                DgPatientBills.ItemsSource = a;
                DgPatientBills.Items.Refresh();

                UltimateMedDB.Business.Patient selectedPatient = currentViewModel.SelectedPatient;
                PatientName.Text = selectedPatient.Name;
                PatientAge.Text = (selectedPatient.Age).ToString();
                PatientGender.Text = selectedPatient.Gender;
                PatientPhone.Text = selectedPatient.Phone;
                PatientWeight.Text = (selectedPatient.Weight).ToString();
                PatientAddress.Text = selectedPatient.Address;
                PatientDocId.Text = selectedPatient.Doc_Id;
                PatientDisease.Text = selectedPatient.Disease;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //When user clicks this button we want to save to the currently selected patient
            //The lab information populated in the Text Boxes
            UltimateMedDBWPFClient.Billing.PatientBillingViewModel currentViewModel =
                (UltimateMedDBWPFClient.Billing.PatientBillingViewModel)DataContext;


            if (currentViewModel.NewBill != null && currentViewModel.SelectedPatient != null)
            {
                Patient patient = currentViewModel.SelectedPatient;
                Bill newBill = currentViewModel.NewBill;
                newBill.DoctorCharge = Decimal.Parse(BillDoctorCharge.Text);
                newBill.InsuranceCarrier = BillInsuranceCarrier.Text;
                newBill.LabCharge = Decimal.Parse(BillLabCharge.Text);
                newBill.NursingCharge = Decimal.Parse(BillNursingCharge.Text);
                newBill.OperationCharge = Decimal.Parse(BillOperationCharge.Text);
                newBill.RoomCharge = Decimal.Parse(BillRoomCharge.Text);
                newBill.MedicineCharge = Decimal.Parse(BillMedicineCharge.Text);
                newBill.PatientType = BillPatientType.Text;
                newBill.BillTotal = newBill.DoctorCharge + newBill.LabCharge + newBill.NursingCharge + newBill.OperationCharge
                    + newBill.RoomCharge + newBill.MedicineCharge;
                Bill.AssignNewBill(newBill, patient.Name);
                MessageBox.Show("Bill has been successfully added to Patient's Account");
                BillDoctorCharge.Text = null;
                BillInsuranceCarrier.Text = null;
                BillLabCharge.Text = null;
                BillNursingCharge.Text = null;
                BillOperationCharge.Text = null;
                BillRoomCharge.Text = null;
                BillMedicineCharge.Text = null;
                BillPatientType.Text = null;
            }
        }

    }
}