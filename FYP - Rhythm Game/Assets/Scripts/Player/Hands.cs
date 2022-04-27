using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using GameManager;

namespace controller
{
    public class Hands : MonoBehaviour
    {
        [Header("Devices")]
        public InputDevice device;
        public InputDeviceCharacteristics controllerCharacteristics;
        public List<InputDevice> devices = new List<InputDevice>();
        private bool triggerValue;

        [Header("Classes")]
        public GameStates gameState;

        private void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            GetDevices();

            if(gameState == null)
            {
                gameState = FindObjectOfType<GameStates>();
            }
            
        }

       public void GetDevices()
        {

            InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

            var primeButton = CommonUsages.primaryButton;
            var SeconButton = CommonUsages.secondaryButton;

            foreach (var device in devices)
            {
                Vector3 position;
                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out position))
                {
                    
                    transform.localPosition = position;
                }

                Quaternion orientation;
                if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out orientation))
                {
                    
                    transform.localRotation = orientation;
                }

                var controllerInput1 = device.TryGetFeatureValue(primeButton, out triggerValue) && triggerValue;

                if(controllerInput1)
                {
                   
                    if (gameState != null)
                    {
                        if (!gameState.isPaused)
                        {
                            gameState.pauseGame();
                            Debug.Log("pause");
                        }
                    }
                }

                var controllerInput2 = device.TryGetFeatureValue(SeconButton, out triggerValue) && triggerValue;

                if (controllerInput2)
                {
                    if (gameState != null)
                    {
                        if (gameState.isPaused)
                        {
                            gameState.resumeGame();
                        }
                    }
                }

            }
        }

        

        

    


    }
}
