using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Ribbon;
using SPD.BL;
using SPD.BL.Interfaces;
using SPD.CommonObjects;
using SPD.CommonUtilities;
using SPD.GUI.WPF;

namespace SPDGUIWPF {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow {

        private ISPDBL patCom;

        public MainWindow() {
            InitializeComponent();

            patCom = new SPDBL();

            searchPanel.Visibility = Visibility.Collapsed;
            detailPanel.Visibility = Visibility.Collapsed;
        }

        
        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e) {
            searchPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void searchToggle_Unchecked(object sender, RoutedEventArgs e) {
            searchPanel.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void viewAllPatients_Checked(object sender, RoutedEventArgs e) {
            searchPanel.IsEnabled = false;
        }

        private void viewAllPatients_Unchecked(object sender, RoutedEventArgs e) {
            searchPanel.IsEnabled = true;
        }

        private void ListViewMain_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void ListViewMain_MouseUp(object sender, MouseButtonEventArgs e) {
            //if (e.OriginalSource is System.Windows.Controls.Decorator) {
            //    ContextMenuPatientValues.IsOpen = true;
            //} else {
            //    ContextMenuPatientValues.IsOpen = false;
            //}

            
            //MessageBox.Show("Mouse Up " + e.OriginalSource+ " " + (e.OriginalSource is System.Windows.Controls.Border));
            //MessageBox.Show("Mouse Up " + e.OriginalSource + " " + (e.OriginalSource is System.Windows.Controls.Decorator));
            //ClassicBorderDecoration

            //ContextMenuPatientValues.IsOpen = true;
            //foreach (MenuItem o in TheContextMenu.Items)
            //{
            //    MessageBox.Show(o.IsChecked.ToString());
            //}
        }

        private void MenuItem_Checked_1(object sender, RoutedEventArgs e) {
            MessageBox.Show("Checked\r\n\r\n" + e.Source + "\r\n\r\n" + e.OriginalSource);
        }

        private void MenuItem_Unchecked_1(object sender, RoutedEventArgs e) {
            MessageBox.Show("UnChecked");
        }

        private void textBoxSearchIdOrName_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                searchIdOrName();
            }
        }

        private void searchIdOrName() {
            if (string.IsNullOrWhiteSpace(textBoxSearchIdOrName.Text)) {
                MessageBox.Show("Please Enter a valid search pattern!");
                return;
            }

            collapseAllCenterElements();
            ListViewMain.Visibility = System.Windows.Visibility.Visible;
            ListViewMain.Items.Clear();
            foreach (PatientData patientData in patCom.FindPatientByIdAndAllName(textBoxSearchIdOrName.Text.Trim())) {
                ListViewMain.Items.Add(PatientBeanConverter.convert(patientData, patCom));
            }
        }

        private void buttonViewAllPatients_Click(object sender, RoutedEventArgs e) {
            collapseAllCenterElements();
            ListViewMain.Visibility = System.Windows.Visibility.Visible;
            ListViewMain.Items.Clear();
            foreach (PatientData patientData in patCom.GetAllPatients()) {
                ListViewMain.Items.Add(PatientBeanConverter.convert(patientData, patCom));
            }
        }

        private void ButtonAddPatient_Click(object sender, RoutedEventArgs e) {
            //MessageBox.Show("New Patient!!");
            collapseAllCenterElements();
            detailPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void collapseAllCenterElements() {
            ListViewMain.Visibility = System.Windows.Visibility.Collapsed;
            detailPanel.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void buttonSerachIdOrName_Click(object sender, RoutedEventArgs e) {
            searchIdOrName();
        }

    }
}
