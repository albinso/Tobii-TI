using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using TI_WindowsLib;

namespace TobiiGUI
{
    public class Configuration : ButtonListener
    {
        public enum ButtonEnum { Right, Left, Both }
        public enum DeviceEnum { Mouse, Keyboard, Command }

        private Dictionary<ButtonEnum, DeviceEnum> keyToDevice;
        private Dictionary<ButtonEnum, object> keyToFunction;

        public static Dictionary<string, ButtonEnum> buttonChoices;
        public static Dictionary<string, DeviceEnum> deviceChoices;

        static Dictionary<string, object> mouseFunctions;
        static Dictionary<string, object> keyBoardFunctions;
        static Dictionary<string, object> commandFunctions;

        static Dictionary<string, object>[] deviceFunctions;

        public Configuration()
        {
            keyToDevice = new Dictionary<ButtonEnum,DeviceEnum>();
            keyToFunction = new Dictionary<ButtonEnum, object>();

            /////////////// Button Dictionary /////////////////
            buttonChoices = new Dictionary<string, ButtonEnum> {
                {"Right", ButtonEnum.Right},
                {"Left", ButtonEnum.Left},
                {"Both", ButtonEnum.Both}
            };

            ////////////// Device Dictionary /////////////////
            deviceChoices = new Dictionary<string, DeviceEnum> {
                {"Mouse", DeviceEnum.Mouse},
                {"Keyboard", DeviceEnum.Keyboard},
                {"Command", DeviceEnum.Command}
            };

            //////////// Functions Dictionary ////////////////
            mouseFunctions = new Dictionary<string, object> {
                {"Right click", (MouseHandling.MOUSEEVENTF_RIGHTUP | MouseHandling.MOUSEEVENTF_RIGHTDOWN)},
                {"Left click", (MouseHandling.MOUSEEVENTF_LEFTUP | MouseHandling.MOUSEEVENTF_LEFTDOWN)},
            };

            keyBoardFunctions = new Dictionary<string, object> {
                {"Alt + F4", "%{F4}"},
                {"Ctrl + Tab", "^{Tab}"},
                {"Ctrl + T", "^{T}"},
                {"Right", "{RIGHT}"},
                {"Left", "{LEFT}"},
                //{"Custom", "kb"}
            };

            commandFunctions = new Dictionary<string, object> {
                {"Launch Chrome", @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"},
                {"Launch Music", @"C:\Program Files (x86)\Windows Media Player\wmplayer.exe"},
                {"Choose file", "cf"}
            };

            deviceFunctions = new Dictionary<string, object>[] {
                mouseFunctions, 
                keyBoardFunctions,
                commandFunctions
            };
        }

        
        public static Dictionary<string, object> GetFunctions(DeviceEnum choice)
        {
            return deviceFunctions[(int) choice];
        }

        public void BindFunction(ButtonEnum buttonChoice, DeviceEnum deviceChoice, object functionChoice)
        {
            keyToDevice.Remove(buttonChoice);
            keyToFunction.Remove(buttonChoice);

            keyToDevice.Add(buttonChoice, deviceChoice);
            keyToFunction.Add(buttonChoice, functionChoice);
        }

        private void PerformAction(ButtonEnum button)
        {
            if (!keyToDevice.ContainsKey(button))
            {
                return;
            }

            DeviceEnum device = keyToDevice[button];
            switch (device)
            {
                case DeviceEnum.Mouse:
                    MouseHandling.MouseClick(Convert.ToUInt32(keyToFunction[button]));
                    break;
                case DeviceEnum.Keyboard:
                    SendKeys.SendWait((string)keyToFunction[button]);
                    break;
                case DeviceEnum.Command:
                    Process process = new Process();
                    process.StartInfo.FileName = (string)keyToFunction[button];
                    process.Start();
                    break;
                default:
                    break;
            }
        }

        override public void OnLeft(BLEButton button, DateTimeOffset timestamp)
        {
            PerformAction(ButtonEnum.Left);
            MessageBox.Show("Pressed left");
        }

        override public void OnRight(BLEButton button, DateTimeOffset timestamp)
        {
            PerformAction(ButtonEnum.Right);
        }

        override public void OnBoth(BLEButton button, DateTimeOffset timestamp)
        {
            PerformAction(ButtonEnum.Both);
        }
    }
}
