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

namespace UltimateMedDBWPFClient.Labs
{
    /// <summary>
    /// Interaction logic for LabView.xaml
    /// </summary>
    public partial class LabView : UserControl
    {
        public LabView()
        {
            InitializeComponent();
        }
        private void CboAllPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Obtain the view model dataContext
            UltimateMedDBWPFClient.Labs.LabViewModel currentViewModel =
                (UltimateMedDBWPFClient.Labs.LabViewModel)DataContext;

            if (currentViewModel != null)
            {
                var a = currentViewModel.LabsByPatient;

                //Assign the ItemsSource of the Patient's Labs DataGrid to the newly obtained object
                DgLabs.ItemsSource = a;
                DgLabs.Items.Refresh();


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
            UltimateMedDBWPFClient.Labs.LabViewModel currentViewModel =
                (UltimateMedDBWPFClient.Labs.LabViewModel)DataContext;


            if (currentViewModel.NewLab != null && currentViewModel.SelectedPatient != null)
            {
                currentViewModel.NewLab.Amount = Decimal.Parse(LabAmount.Text);
                currentViewModel.NewLab.Category = LabCategory.Text;
                currentViewModel.NewLab.Date = DateTime.Parse(LabDate.Text);
                currentViewModel.NewLab.PatientType = LabPatientType.Text;
                currentViewModel.NewLab.Weight = int.Parse(LabWeight.Text);
                currentViewModel.NewLab.Doc_id = int.Parse(LabDocId.Text);

                Lab.AddLab(currentViewModel.NewLab, currentViewModel.SelectedPatient.Name);
                MessageBox.Show("Lab has been successfully added to Patient's Account");
                LabAmount.Text = null;
                LabCategory.Text = null;
                LabDate.Text = null;
                LabPatientType.Text = null;
                LabWeight.Text = null;
                LabDocId.Text = null;

            }
        }
    }
}
