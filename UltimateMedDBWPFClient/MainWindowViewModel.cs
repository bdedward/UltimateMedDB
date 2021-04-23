using System;
using System.Linq;
using UltimateMedDB.Business;
using UltimateMedDBWPFClient;
using UltimateMedDBWPFClient.Billing;
using UltimateMedDBWPFClient.Labs;

namespace UltimateMedDBWPFClient
{
    class MainWindowViewModel : BindableBase
    {
        private PatientBillingViewModel _billingViewModel = new PatientBillingViewModel();
        private LabViewModel _labViewModel = new LabViewModel();
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
                default:
                    CurrentViewModel = _labViewModel;
                    break;
            }
        }

        private void NavToOrder(Guid customerId)
        {
            //_billing = customerId;
            //CurrentViewModel = _orderViewModel;
        }
/*
        private void NavToAddCustomer(Billing cust)
        {
            _addEditViewModel.EditMode = false;
            _addEditViewModel.SetCustomer(cust);
            CurrentViewModel = _addEditViewModel;
        }

        private void NavToEditCustomer(Customer cust)
        {
            _addEditViewModel.EditMode = true;
            _addEditViewModel.SetCustomer(cust);
            CurrentViewModel = _addEditViewModel;
        }
*/
    }
}
