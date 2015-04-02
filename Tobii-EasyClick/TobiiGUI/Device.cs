using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobiiGUI
{
    class Device
    {
        static Dictionary<string, object> mouseFunctions = new Dictionary<string, object> {
            {"Left click", 1},
            {"Right click", 2}
        };

        static Dictionary<string, object> keyBoardFunctions = new Dictionary<string, object>
        {
            {"Alt + F4", 3},
            {"Alt + Tab", 4}
        };

        static Dictionary<string, object> commandFunctions = new Dictionary<string, object>
        {
            {"Launch Chrome", 5},
            {"Launch Music", 6}
        };
        static SelectionForm.ButtonEnum buttonChoice;
        static SelectionForm.DeviceEnum deviceChoice;
        static object functionChoice;

        static Dictionary<string, object>[] deviceFunctions = new Dictionary<string, object>[] { mouseFunctions, keyBoardFunctions, commandFunctions };
        
        public static Dictionary<string, object> GetFunctions(SelectionForm.DeviceEnum choice)
        {
            return deviceFunctions[(int) choice];
        }

        public static void BindFunction(SelectionForm.ButtonEnum buttonChoice, SelectionForm.DeviceEnum deviceChoice, object functionChoice)
        {
            Device.buttonChoice = buttonChoice;
            Device.deviceChoice = deviceChoice;
            Device.functionChoice = functionChoice;
        }


    }
}
