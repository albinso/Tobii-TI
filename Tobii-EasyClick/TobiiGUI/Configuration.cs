using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using TrampzSDK;

namespace TobiiGUI
{
    public class Configuration : BLEButtonListener
    {
        public enum ClickEnum { Right, Left, Both }
        public enum DeviceEnum { Mouse, Keyboard, Command, None }

        private Dictionary<ClickEnum, DeviceEnum> keyToDevice;
        private Dictionary<ClickEnum, object> keyToFunction;

        /////////////// Click Dictionary /////////////////
        public static Dictionary<string, ClickEnum> clickChoices = new Dictionary<string, ClickEnum> {
                {"Right", ClickEnum.Right},
                {"Left", ClickEnum.Left},
                {"Both", ClickEnum.Both}
            };

        ////////////// Device Dictionary /////////////////
        public static Dictionary<string, DeviceEnum> deviceChoices = new Dictionary<string, DeviceEnum> {
                {"Mouse", DeviceEnum.Mouse},
                {"Keyboard", DeviceEnum.Keyboard},
                {"Command", DeviceEnum.Command},
                {"None", DeviceEnum.None}
            };

        //////////// Functions Dictionary ////////////////
        static Dictionary<string, object> mouseFunctions = new Dictionary<string, object> {
                {"Right click", (MouseHandling.MOUSEEVENTF_RIGHTUP | MouseHandling.MOUSEEVENTF_RIGHTDOWN)},
                {"Left click", (MouseHandling.MOUSEEVENTF_LEFTUP | MouseHandling.MOUSEEVENTF_LEFTDOWN)},
            };
        static Dictionary<string, object> keyBoardFunctions = new Dictionary<string, object> {
                {"Alt + F4", "%{F4}"},
                {"Ctrl + Tab", "^{Tab}"},
                {"Ctrl + T", "^{T}"},
                {"Right", "{RIGHT}"},
                {"Left", "{LEFT}"},
                {"Up", "{UP}"},
                {"Down", "{DOWN}"},
                {"W", "{W}"},
                {"Custom", "kb"}
            };

        static Dictionary<string, object> commandFunctions = new Dictionary<string, object> {
                {"Launch Chrome", @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"},
                {"Launch Music", @"C:\Program Files (x86)\Windows Media Player\wmplayer.exe"},
                {"Choose file", "cf"}
            };

        static Dictionary<string, object> noneFunctions = new Dictionary<string, object> { 
            {"None", ""}
        
        };

        static Dictionary<string, object>[] deviceFunctions = new Dictionary<string, object>[] {
                mouseFunctions, 
                keyBoardFunctions,
                commandFunctions,
                noneFunctions
            };

        public Configuration()
        {
            keyToDevice = new Dictionary<ClickEnum,DeviceEnum>();
            keyToFunction = new Dictionary<ClickEnum, object>();         
        }

        
        public static Dictionary<string, object> GetFunctions(DeviceEnum choice)
        {
            return deviceFunctions[(int) choice];
        }

        public void BindFunction(ClickEnum clickChoice, DeviceEnum deviceChoice, object functionChoice)
        {
            keyToDevice.Remove(clickChoice);
            keyToFunction.Remove(clickChoice);

            keyToDevice.Add(clickChoice, deviceChoice);
            keyToFunction.Add(clickChoice, functionChoice);
        }

        private void PerformAction(ClickEnum click)
        {
            if (!keyToDevice.ContainsKey(click))
            {
                return;
            }

            DeviceEnum device = keyToDevice[click];
            switch (device)
            {
                case DeviceEnum.Mouse:
                    MouseHandling.MouseClick(Convert.ToUInt32(keyToFunction[click]));
                    break;
                case DeviceEnum.Keyboard:
                    SendKeys.SendWait((string)keyToFunction[click]);
                    break;
                case DeviceEnum.Command:
                    Process process = new Process();
                    process.StartInfo.FileName = (string)keyToFunction[click];
                    process.Start();
                    break;
                case DeviceEnum.None:
                    break;
                default:
                    break;
            }
        }

        override public void OnLeft(BLEButton button, DateTimeOffset timestamp)
        {
            PerformAction(ClickEnum.Left);
        }

        override public void OnRight(BLEButton button, DateTimeOffset timestamp)
        {
            PerformAction(ClickEnum.Right);
        }

        override public void OnBoth(BLEButton button, DateTimeOffset timestamp)
        {
            PerformAction(ClickEnum.Both);
        }
    }
}
