using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TI_WindowsLib;

namespace TobiiGUI
{
    public partial class SelectionForm : Form
    {
        Configuration.ButtonEnum buttonChoice = Configuration.ButtonEnum.Right;
        Configuration.DeviceEnum deviceChoice = Configuration.DeviceEnum.Mouse;
        object functionChoice;

        private Dictionary<string, BLEButton> bleChoices = new Dictionary<string, BLEButton>();

        BLEButton currentBle;
        public SelectionForm()
        {
            InitializeComponent();

            Task waitMe = Task.Run(() => PopulateBleComboBox());
            waitMe.Wait();
            testAndRemoveButtons();
            InitializeComboBoxes();

        }

        private async void testAndRemoveButtons()
        {
            Dictionary<string, BLEButton> updatedBleChoices = new Dictionary<string, BLEButton>();
            int count = bleChoices.Count;
            int percentage = 100/count;
            progressBar.Value = 100%count+1;
            foreach (KeyValuePair<string, BLEButton> entry in bleChoices)
            {
                if (await entry.Value.Connect())
                {
                    updatedBleChoices.Add(entry.Key, entry.Value);
                }
                int sum = progressBar.Value + percentage;
                progressBar.Value = sum > 100 ? 100 : sum;
            }

            bleChoices = updatedBleChoices;
            bleComboBox.DataSource = new BindingSource(bleChoices, null);
        }

        List<BLEButton> buttonList;
        private async Task PopulateBleComboBox()
        {
            
            BLEButtonFactory factory = new BLEButtonFactory();
            await factory.Scan();
            buttonList = factory.GetAllButtons();
            try
            {
                currentBle = buttonList[0];

                int i = 1;
                foreach (BLEButton b in buttonList)
                {
                    Configuration config = new Configuration();
                    b.Listener = config;
                    string bleName = "BLE " + Convert.ToString(i);
                    bleChoices.Add(bleName, b);
                    i += 1;
                }
            }
            catch
            {
                Console.WriteLine("Found no buttons...");
            }
            
        }

        private void InitializeComboBoxes()
        {
            buttonComboBox.DataSource = new BindingSource(Configuration.buttonChoices, null);
            buttonComboBox.ValueMember = "Value";
            buttonComboBox.DisplayMember = "Key";

            deviceComboBox.DataSource = new BindingSource(Configuration.deviceChoices, null);
            deviceComboBox.ValueMember = "Value";
            deviceComboBox.DisplayMember = "Key";

            functionComboBox.DataSource = new BindingSource(Configuration.GetFunctions(Configuration.DeviceEnum.Mouse), null);
            functionComboBox.ValueMember = "Value";
            functionComboBox.DisplayMember = "Key";

            bleComboBox.DataSource = new BindingSource(bleChoices, null);
            bleComboBox.ValueMember = "Value";
            bleComboBox.DisplayMember = "Key";
        }

        private void bleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, BLEButton> choice = (KeyValuePair<string, BLEButton>)bleComboBox.SelectedItem;
            BLEButton bleChoice = choice.Value;
            currentBle = bleChoice;
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
            functionComboBox.DataSource = new BindingSource(Configuration.GetFunctions(deviceChoice), null);
        }

        private void functionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {   
            KeyValuePair<string, object> choice = (KeyValuePair<string, object>)functionComboBox.SelectedItem;
            functionChoice = choice.Value;

            if (functionChoice.ToString().Equals("cf"))
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    functionChoice = openFileDialog1.FileName;
                }
            }

            //if (functionChoice.ToString().Equals("kb"))
            //{
                
            //    functionChoice = ShowDialog("Enter keyboard input", "Keyboard");
            //}
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            Configuration c = (Configuration)(currentBle.Listener);
            c.BindFunction(buttonChoice, deviceChoice, functionChoice);
        }

        private void SelectionForm_Load(object sender, EventArgs e)
        {

        }


   
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        //public static string ShowDialog(string text, string caption)
        //{
        //    Form prompt = new Form();
        //    prompt.Width = 500;
        //    prompt.Height = 150;
        //    prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    prompt.Text = caption;
        //    prompt.StartPosition = FormStartPosition.CenterScreen;
        //    Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
        //    TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
        //    Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
        //    confirmation.Click += (sender, e) => { prompt.Close(); };
        //    prompt.Controls.Add(textBox);
        //    prompt.Controls.Add(confirmation);
        //    prompt.Controls.Add(textLabel);
        //    prompt.AcceptButton = confirmation;
        //    prompt.ShowDialog();
        //    return textBox.Text;
        //}

    }
}
