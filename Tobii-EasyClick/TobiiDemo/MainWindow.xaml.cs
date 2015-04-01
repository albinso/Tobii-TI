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
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using System.Windows.Forms;

namespace TobiiDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BLE_Utilities.Start();
        }


        private async void RightComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void LeftComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void BothComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private void InitializeComboBox()
        //{

        //    Dictionary<string, string> choices = new Dictionary<string, string>();
        //    choices.Add("^{Tab}", "Alt + Tab");
        //    choices.Add("%{F4}", "Alt + F4");

        //    leftButtonComboBox.DisplayMemberPath = "Value";
        //    leftButtonComboBox.SelectedValuePath = "Key";

        //    rightButtonComboBox.DisplayMemberPath = "Value";
        //    rightButtonComboBox.SelectedValuePath = "Key";

        //    bothButtonComboBox.DisplayMemberPath = "Value";
        //    bothButtonComboBox.SelectedValuePath = "Key";

        //    leftButtonComboBox.SelectedIndex = 0;
        //    rightButtonComboBox.SelectedIndex = 0;
        //    bothButtonComboBox.SelectedIndex = 1;

        //    leftButtonComboBox.ItemsSource = choices;
        //    rightButtonComboBox.ItemsSource = choices;
        //    bothButtonComboBox.ItemsSource = choices;
        //}


        //private void RightComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    string value = rightButtonComboBox.SelectedValue.ToString();
        //    rightButton = value;
        //}

    }
}
