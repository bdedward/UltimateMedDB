using System;
using System.Linq;
using UltimateMedDB.Business;
using UltimateMedDBWPFClient;
using UltimateMedDBWPFClient.Billing;
using UltimateMedDBWPFClient.Labs;
using UltimateMedDBWPFClient.Patients;
using UltimateMedDBWPFClient.Rooms;

namespace UltimateMedDBWPFClient
{
    class MainWindowViewModel : BindableBase
    {
        private PatientBillingViewModel _billingViewModel = new PatientBillingViewModel();
        private LabViewModel _labViewModel = new LabViewModel();
        private PatientViewModel _patientViewModel = new PatientViewModel();
        private RoomViewModel _roomViewModel = new RoomViewModel();
        //private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();
        //private AddEditCustomerViewModel _addEditViewModel = new AddEditCustomerViewModel();

        public MainWindowViewModel()
        {
            //This currently works to display the Patient Bill info
            //_CurrentViewModel = _billingViewModel;


            NavCommand = new RelayCommand<string>(OnNav);
            //_billingViewModel.AllPatients += NavToOrder;
            //_customerListViewModel.AddCustomerRequested += NavToAddCustomer;
            //_customerListViewModel.EditCustomerRequested += NavToEditCustomer;
        }

        private BindableBase _CurrentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public RelayCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "billing":
                    CurrentViewModel = _billingViewModel;
                    break;
                case "labs":
                    CurrentViewModel = _labViewModel;
                    break;
                case "patients":
                    CurrentViewModel = _patientViewModel;
                    break;
                case "rooms":
                    CurrentViewModel = _roomViewModel;
                    break;
            }
        }

    }
}
