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

namespace UltimateMedDBWPFClient.Rooms
{
    /// <summary>
    /// Interaction logic for RoomView.xaml
    /// </summary>
    public partial class RoomView : UserControl
    {
        public RoomView()
        {
            InitializeComponent();
        }

        private void CboAllPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Obtain the view model dataContext
            UltimateMedDBWPFClient.Rooms.RoomViewModel currentViewModel =
                (UltimateMedDBWPFClient.Rooms.RoomViewModel)DataContext;

            if (currentViewModel != null)
            {
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
            //Obtain the view model dataContext
            UltimateMedDBWPFClient.Rooms.RoomViewModel currentViewModel =
                (UltimateMedDBWPFClient.Rooms.RoomViewModel)DataContext;

            //Get the new List<Room> object from the current view model
            var a = currentViewModel.AvailableRooms;

            //Assign the ItemsSource of the Patient's Bill DataGrid to the newly obtained object
            dgAvailableRooms.ItemsSource = a;
            dgAvailableRooms.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UltimateMedDBWPFClient.Rooms.RoomViewModel currentViewModel =
                (UltimateMedDBWPFClient.Rooms.RoomViewModel)DataContext;
            Room.AddNewRoom(currentViewModel.NewRoom);


        }
    }
}
