using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;
using System.Windows.Forms;

namespace Tobii_EasyClick
{
    class Program
    {
        private const string UUID_KEY_SERV = "0000ffe0-0000-1000-8000-00805f9b34fb";
        private const string UUID_KEY_DATA = "0000ffe1-0000-1000-8000-00805f9b34fb";

        static void Main(string[] args)
        {
            executeOnNotification(buttonPressed);
            Console.ReadLine();//This is only so that terminal doesn't close immediately
        }

        private static async void executeOnNotification(Windows.Foundation.TypedEventHandler<GattCharacteristic, GattValueChangedEventArgs> methodToExecute)
        {
            //Get gatt characteristic
            GattCharacteristic characteristic = await GetCharacteristic(UUID_KEY_SERV, UUID_KEY_DATA);

            //Enable notifications
            GattCommunicationStatus status = await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);

            characteristic.ValueChanged -= methodToExecute;
            //WARNING!!! the "+=" tells event listener to CALL a delagate method.
            characteristic.ValueChanged += methodToExecute;
        }

        static byte[] getDataBytes(GattValueChangedEventArgs args)
        {
            //Create a byte array(with same size as the caracteristics value)
            var data = new byte[args.CharacteristicValue.Length];

            //Read to byte array from args
            DataReader.FromBuffer(args.CharacteristicValue).ReadBytes(data);
            return data;
        }


        /// <summary>
        /// This is an eventHandler delegate that will be called by an event handler.
        /// </summary>
        /// <param name="sender">the gatt characteristic that was changed</param>
        /// <param name="args">contains all kinds of data</param>
        static void buttonPressed(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            //Create a byte array(with same size as the caracteristics value)
            Byte[] data = getDataBytes(args);

            //Display "HIT" on console and print out data.
            Console.WriteLine("HIT");
            //1 is LEFT BUTTON, 2 is RIGHT BUTTON, 3 is BOTH.
            if (data[0] == 1)
            {
                Console.WriteLine(data[0]);                     
            }

            if (data[0] == 2)
            {
                Console.WriteLine(data[0]);
            }

            if (data[0] == 3)
            {
                Console.WriteLine(data[0]);
            }
            if (data[0] == 0)
            {
                Console.WriteLine(data[0]);

            }

        }


        /// <summary>
        /// Returns a GATT characteristic for a sensor's data service.
        /// </summary>
        /// <param name="sensor">the sensor you want to read</param>
        /// <returns>the GATT characteristic</returns>
        static async Task<GattCharacteristic> GetCharacteristic(string UUID_Service, string UUID_Data)
        {

            //Get a query for devices with this service
            string deviceSelector = GattDeviceService.GetDeviceSelectorFromUuid(new Guid(UUID_Service));

            //seek devices using the query
            var deviceCollection = await DeviceInformation.FindAllAsync(deviceSelector);

            //return info for the first device you find
            DeviceInformation device = deviceCollection.FirstOrDefault();

            if (device == null)
                throw new Exception("Device not found.");

            // using the id get the service
            GattDeviceService service = await GattDeviceService.FromIdAsync(device.Id);

            //get all characteristics
            IReadOnlyList<GattCharacteristic> characteristics = service.GetCharacteristics(new Guid(UUID_Data));

            if (characteristics.Count == 0)
                throw new Exception("characteristic not found.");

            //Reaturn event handler for first characteristic
            return characteristics[0];
        }
    }
}
