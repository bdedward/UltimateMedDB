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

    }
}
