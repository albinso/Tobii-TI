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

        Dictionary<string, object> functionChoices;

        Configuration.ButtonEnum buttonChoice = Configuration.ButtonEnum.Right;
        Configuration.DeviceEnum deviceChoice = Configuration.DeviceEnum.Mouse;
        object functionChoice;
        public SelectionForm()
        {

            //Manager m = new Manager();
            //myList = m.StartScan;
            //myButton = myList[0];
            //myButton.connect();
            //Event listner = new MyListerInterface();
            //myButton.setEvent(lister);

            InitializeComponent();

            Configuration config = new Configuration();

            BLE_Utilities.SetListener(config);
            BLE_Utilities.Start();

            InitializeComboBox();

        }


        private void InitializeComboBox()
        {
            Dictionary<string, Configuration.ButtonEnum> buttonChoices = new Dictionary<string, Configuration.ButtonEnum>();
            buttonChoices.Add("Right", Configuration.ButtonEnum.Right);
            buttonChoices.Add("Left", Configuration.ButtonEnum.Left);
            buttonChoices.Add("Both", Configuration.ButtonEnum.Both);
            buttonComboBox.DataSource = new BindingSource(buttonChoices, null);
            buttonComboBox.ValueMember = "Value";
            buttonComboBox.DisplayMember = "Key";

            Dictionary<string, Configuration.DeviceEnum> deviceChoices = new Dictionary<string, Configuration.DeviceEnum>();
            deviceChoices.Add("Mouse", Configuration.DeviceEnum.Mouse);
            deviceChoices.Add("Keyboard", Configuration.DeviceEnum.Keyboard);
            deviceChoices.Add("Command", Configuration.DeviceEnum.Command);
            deviceComboBox.DataSource = new BindingSource(deviceChoices, null);
            deviceComboBox.ValueMember = "Value";
            deviceComboBox.DisplayMember = "Key";

            functionChoices = Configuration.GetFunctions(Configuration.DeviceEnum.Mouse);
            functionComboBox.DataSource = new BindingSource(functionChoices, null);
            functionComboBox.ValueMember = "Value";
            functionComboBox.DisplayMember = "Key";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, Configuration.ButtonEnum> choice = (KeyValuePair<string, Configuration.ButtonEnum>)buttonComboBox.SelectedItem;
            buttonChoice = choice.Value;
        }

        private void deviceCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, Configuration.DeviceEnum> choice = (KeyValuePair<string, Configuration.DeviceEnum>)deviceComboBox.SelectedItem;
            deviceChoice = choice.Value;

            functionChoices = Configuration.GetFunctions(deviceChoice);
            functionComboBox.DataSource = new BindingSource(functionChoices, null);
        }

        private void functionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {       
            KeyValuePair<string, object> choice = (KeyValuePair<string, object>)functionComboBox.SelectedItem;
            functionChoice = choice.Value;

            if (functionChoice.ToString().Equals(""))
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    functionChoice = openFileDialog1.FileName;
                }
            }
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            Configuration c = (Configuration)(BLE_Utilities.listener);
            c.BindFunction(buttonChoice, deviceChoice, functionChoice);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
