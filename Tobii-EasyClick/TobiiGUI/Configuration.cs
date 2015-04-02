using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TobiiGUI
{
    public class Configuration : ButtonListener
    {
        public enum ButtonEnum { Right, Left, Both }
        public enum DeviceEnum { Mouse, Keyboard, Command }


        ButtonEnum buttonChoice;
        DeviceEnum deviceChoice;
        object functionChoice;

        private Dictionary<ButtonEnum, DeviceEnum> keyToDevice;
        private Dictionary<ButtonEnum, object> keyToFunction;

        static Dictionary<string, object> mouseFunctions = new Dictionary<string, object> {
            {"Left click", (MouseHandling.MOUSEEVENTF_LEFTUP | MouseHandling.MOUSEEVENTF_LEFTDOWN)},
            {"Right click", (MouseHandling.MOUSEEVENTF_RIGHTUP | MouseHandling.MOUSEEVENTF_RIGHTDOWN)}
        };

        static Dictionary<string, object> keyBoardFunctions = new Dictionary<string, object>
        {
            {"Alt + F4", "%{F4}"},
            {"Ctrl + Tab", "^{Tab}"}
        };

        static Dictionary<string, object> commandFunctions = new Dictionary<string, object>
        {
            {"Launch Chrome", @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"},
            {"Launch Music", @"C:\Program Files (x86)\Windows Media Player\wmplayer.exe"},
            {"Choose file", ""}

        };

        public Configuration()
        {
            keyToDevice = new Dictionary<ButtonEnum,DeviceEnum>();
            keyToFunction = new Dictionary<ButtonEnum, object>();
        }

        static Dictionary<string, object>[] deviceFunctions = new Dictionary<string, object>[] {
            mouseFunctions, 
            keyBoardFunctions,
            commandFunctions
        };
        
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

        override public void OnButtonClickOrHold(BLE_Utilities button, bool isClick, bool isHold)
        {
            if (isClick)
            {
                PerformAction(ButtonEnum.Right);             
            }
            if (isHold)
            {
                PerformAction(ButtonEnum.Both);
            }
        }
        override public void OnButtonSingleOrDoubleClick(BLE_Utilities button, bool isSingleClick, bool isDoubleClick)
        {
            if (isDoubleClick)
            {
                PerformAction(ButtonEnum.Left);
            }
        }

        override public void OnButtonSingleOrDoubleClickOrHold(BLE_Utilities button, bool isSingleClick, bool isDoubleClick, bool isHold)
        {

        }
    }
}
