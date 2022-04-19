using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

namespace controller
{
    public class Hands : MonoBehaviour
    {
        [Header("Devices")]
        public InputDevice device;
        public InputDeviceCharacteristics controllerCharacteristics;
        public List<InputDevice> devices = new List<InputDevice>();

        [Header("TESTING")]
        public bool isRayCast;
        public RayCasting rayCasting;

        // Start is called before the first frame update
        void Start()
        {
            rayCasting = GetComponentInChildren<RayCasting>();
        }

        // Update is called once per frame
        void Update()
        {
            GetDevices();

            if (isRayCast)
            {
                rayCasting.gameObject.SetActive(true);
               
            }

            else
            {
                rayCasting.gameObject.SetActive(false);
                return;
            }
          
        }

       public void GetDevices()
        {

            InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

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


            }
        }

        

    


    }
}
