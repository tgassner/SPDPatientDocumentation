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
using SPD.CommonObjects;

namespace SPD.GUI.WPF {
    /// <summary>
    /// Interaction logic for PatientDetail.xaml
    /// </summary>
    public partial class PatientDetail : UserControl {
        public PatientDetail() {
            InitializeComponent();

            foreach (String sex in Enum.GetNames(new Sex().GetType())) {
                this.listBoxSec.Items.Add(sex);
            }

            //foreach (String ambulant in Enum.GetNames(new Ambulant().GetType())) {
            //    this.listBoxAmbulant.Items.Add(ambulant);
            //}

            //foreach (String resident in Enum.GetNames(new ResidentOfAsmara().GetType())) {
            //    this.listBoxResidentOfAsmara.Items.Add(resident);
            //}

            //foreach (String finished in Enum.GetNames(new Finished().GetType())) {
            //    this.listBoxFinished.Items.Add(finished);
            //}

            //foreach (String linz in Enum.GetNames(new Linz().GetType())) {
            //    this.listBoxLinz.Items.Add(linz);
            //}
        }
    }
}
