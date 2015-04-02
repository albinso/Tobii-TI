using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TobiiGUI
{
    public partial class SelectionForm : Form
    {
        public enum ButtonEnum {Right, Left, Both}
        public enum DeviceEnum { Mouse, Keyboard, Command}

        Dictionary<string, object> functionChoices;

        ButtonEnum buttonChoice;
        DeviceEnum deviceChoice;

        public SelectionForm()
        {

            //Manager m = new Manager();
            //myList = m.StartScan;
            //myButton = myList[0];
            //myButton.connect();
            //Event listner = new MyListerInterface();
            //myButton.setEvent(lister);
            
            InitializeComponent();
            InitializeComboBox();
            BLE_Utilities.Start();

        }


        private void InitializeComboBox()
        {
            Dictionary<string, ButtonEnum> buttonChoices = new Dictionary<string, ButtonEnum>();
            buttonChoices.Add("Right", ButtonEnum.Right);
            buttonChoices.Add("Left", ButtonEnum.Left);
            buttonChoices.Add("Both", ButtonEnum.Both);
            buttonComboBox.DataSource = new BindingSource(buttonChoices, null);
            buttonComboBox.ValueMember = "Value";
            buttonComboBox.DisplayMember = "Key";

            Dictionary<string, DeviceEnum> deviceChoices = new Dictionary<string, DeviceEnum>();
            deviceChoices.Add("Mouse", DeviceEnum.Mouse);
            deviceChoices.Add("Keyboard", DeviceEnum.Keyboard);
            deviceChoices.Add("Command", DeviceEnum.Command);
            deviceComboBox.DataSource = new BindingSource(deviceChoices, null);
            deviceComboBox.ValueMember = "Value";
            deviceComboBox.DisplayMember = "Key";

            functionChoices = Configuration.GetFunctions(DeviceEnum.Mouse);
            functionComboBox.DataSource = new BindingSource(functionChoices, null);
            functionComboBox.ValueMember = "Value";
            functionComboBox.DisplayMember = "Key";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, ButtonEnum> choice = (KeyValuePair<string, ButtonEnum>) buttonComboBox.SelectedItem;
            buttonChoice = choice.Value;
        }

        private void deviceCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, DeviceEnum> choice = (KeyValuePair<string, DeviceEnum>)deviceComboBox.SelectedItem;
            deviceChoice = choice.Value;

            functionChoices = Configuration.GetFunctions(deviceChoice);
            functionComboBox.DataSource = new BindingSource(functionChoices, null);
        }

        private void functionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //KeyValuePair<string, object> choice = (KeyValuePair<string, object>)deviceComboBox.SelectedItem;
            //object functionChoice = choice.Value;
            //Device.BindFunction(buttonChoice, deviceChoice, functionChoice);
        }
    }
}
