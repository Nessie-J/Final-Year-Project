using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class Hands : MonoBehaviour
{
    public InputDevice device;
    public InputDeviceCharacteristics controllerCharacteristics;

    public LayerMask BlockLayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetDevices();
    }

    void GetDevices()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);


        foreach (var device in devices)
        {
            Vector3 position;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out position))
            {
                // NOTE: needs to be local position (i.e. position relative to rig)
                transform.localPosition = position;
            }

            Quaternion orientation;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out orientation))
            {
                // NOTE: needs to be local rotation (i.e. rotation relative to rig)
                transform.localRotation = orientation;
            }


        }
    }
}
