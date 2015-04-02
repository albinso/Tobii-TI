using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobiiGUI
{
    /// <summary>
    /// FlicButton event listener.
    /// This interface defines the callback methods that will be called in 
    /// response to various events fired by the FlicButton class. 
    /// A note on the different click patterns. First, there is the low-level onButtonUpOrDown. 
    /// This will always be triggered when the button is pressed or released. 
    /// There are also three different patterns for different use cases:
    /// onButtonClickOrHold, onButtonSingleOrDoubleClick and onButtonSingleOrDoubleClickOrHold. 
    /// You are free to use anyone that best matches your use case and ignore the others.
    /// </summary>
    public abstract class ButtonListener
    {
        /// <summary>
        /// Battery status event handler.
        /// 
        /// Called after the battery status has changed on the button.
        /// </summary>
        /// <param name="button">The FlicButton that fired the event.</param>
        /// <param name="battery"> a 16 bit unsigned value of an adc sample (will later be replaced with a percent value between 0 and 100)</param>
        public void OnBatteryStatus(BLE_Utilities button, int battery)
        {

        }

        /// <summary>
        /// Button click/hold handler.
        /// Used to distinguish between click and hold. 
        /// Click will be fired when the button is released if it was pressed for maximum 1 second. 
        /// Otherwise, hold will be fired 1 second after the button was pressed. 
        /// Click will then not be fired upon release. One of isClick and isHold will be true, the other will be false.
        /// </summary>
        /// <param name="button">The FlicButton that fired the event.</param>
        /// <param name="isClick">true if it was clicked</param>
        /// <param name="isHold">true if it was held</param>
        public abstract void OnButtonClickOrHold(BLE_Utilities button, bool isClick, bool isHold);
        /// <summary>
        /// Button single/double click handler.
        /// Used to distinguish between single and double click. 
        /// Double click will be fired if the time between two button down events was at most 0.5 seconds. 
        /// The double click event will then be fired upon button release. If the time was more than 0.5 seconds, 
        /// a single click event will be fired; either directly upon button release if the button was down for more
        /// than 0.5 seconds, or after 0.5 seconds if the button was down for less than 0.5 seconds.  
        /// One of isSingleClick and isDoubleClick will be true, the other will be false. 
        /// Note: Three fast consecutive clicks means one double click and then one single click.
        /// Four fast consecutive clicks means two double clicks.
        /// </summary>
        /// <param name="button">The FlicButton that fired the event.</param>
        /// <param name="isSingleClick">true if it was a single click</param>
        /// <param name="isDoubleClick">true if it was a double click</param>
        public abstract void OnButtonSingleOrDoubleClick(BLE_Utilities button, bool isSingleClick, bool isDoubleClick);

        /// <summary>
        /// Button single/double click handler.
        /// Used to distinguish between single click, double click and hold.
        /// If the time between the first button down and button up event was more than 1 second,
        /// a hold event will be fired.  Else, double click will be fired if the time between 
        /// two button down events was at most 0.5 seconds. The double click event will then 
        /// be fired upon button release. If the time was more than 0.5 seconds, a single click
        /// event will be fired; either directly upon button release if the button was down for 
        /// more than 0.5 seconds, or after 0.5 seconds if the button was down for less than 0.5 seconds.
        /// One of isHold, isSingleClick and isDoubleClick will be true, the other ones will be false.
        /// 
        /// Note: Three fast consecutive clicks means one double click and then one single click. 
        /// Four fast consecutive clicks means two double clicks.
        /// </summary>
        /// <param name="button">The FlicButton that fired the event.</param>
        /// <param name="isSingleClick">true if it was a single click</param>
        /// <param name="isDoubleClick">true if it was a double click</param>
        /// <param name="isHold">true if it was a hold</param>
        public abstract void OnButtonSingleOrDoubleClickOrHold(BLE_Utilities button, bool isSingleClick, bool isDoubleClick, bool isHold);


        /// <summary>
        /// Button up/down handler.  Called after the button has been pressed or released. 
        /// One of isUp and isDown will be true, the other will be false.
        /// </summary>
        /// <param name="button">The FlicButton that fired the event.</param>
        /// <param name="isUp">true if it was released</param>
        /// <param name="isDown">true if it was pressed</param>
        public void OnButtonUpOrDown(BLE_Utilities button, bool isUp, bool isDown){
        }


        /// <summary>
        /// Connection event handler.
        /// 
        /// Called after a connection from the Flic button to the
        /// device has completed and the button is ready to use.
        /// </summary>
        /// <param name="button">The FlicButton that fired the event.</param>
        public void OnConnect(BLE_Utilities button) { 
        }

        /// <summary>
        /// Connection failed handler.  
        /// 
        /// Called if a connection fails. 
        /// It is best to restart bluetooth here, since we don't know the reason why it failed. 
        /// Not restarting could result in that we can't connect to it anymore.
        /// After restarting bluetooth, you can immediately connect again.
        /// </summary>
        /// <param name="button">The FlicButton that fired the event.</param>
        /// <param name="status"></param>
        public void OnConnectionFailed(BLE_Utilities button, int status)
        {

        }

        /// <summary>
        /// Disconnection event handler.
        /// 
        /// Called after the Flic button has disconnected.
        /// </summary>
        /// <param name="button">The FlicButton that fired the event.</param>
        public void OnDisconnect(BLE_Utilities button)
        {

        }

        /// <summary>
        /// Read remote rssi event handler.
        /// 
        /// Called after readRemoteRssi.
        /// </summary>
        /// <param name="button">The FlicButton that fired the event.</param>
        /// <param name="rssi">The rssi value</param>
        /// <param name="status">0 if success</param>
        public void OnReadRemoteRssi(BLE_Utilities button, int rssi, int status)
        {

        }
    }
}
