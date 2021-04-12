﻿using System;
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

namespace UltimateMedDBWPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Use implicit casting with caution
            UltimateMedDB.WPFClient.UltimateMedDBViewModel currentViewModel =
                (UltimateMedDB.WPFClient.UltimateMedDBViewModel) DataContext;

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
    }
}
