using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Material touchingMaterial;
    public Material notTouchingMaterial;
    private GameObject currentlyTouching;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rightHandedControllers = new List<UnityEngine.XR.InputDevice>();
        var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, rightHandedControllers);

        foreach (var device in rightHandedControllers)
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

            bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                Debug.Log("Trigger button is pressed.");
                if(currentlyTouching != null)
                {
                    currentlyTouching.transform.position = transform.position;
                    currentlyTouching.transform.rotation = transform.rotation;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        currentlyTouching = other.gameObject;
        var renderer = currentlyTouching.GetComponent<Renderer>();
        renderer.material = touchingMaterial;
    }

    void OnTriggerExit(Collider other)
    {
        var renderer = currentlyTouching.GetComponent<Renderer>();
        renderer.material = notTouchingMaterial;
        currentlyTouching = null;
    }
}
