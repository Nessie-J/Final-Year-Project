using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

namespace controller
{

    public class RayCasting : MonoBehaviour
    { 
        public Hands hands;

        [SerializeField] private float maxDis;
        [SerializeField] private bool isRayActive;

        private float triggerTime = 0;
        private bool lastState = false;
        private bool triggerValue;
        [SerializeField] private LineRenderer lineRender;
        private GameObject selectedObject = null;

        private void Start()
        {
            lineRender = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            projectCast();
        }

        public void projectCast()
        {
            var primairyButton = CommonUsages.primaryButton;

            var controllerInput = hands.device.TryGetFeatureValue(primairyButton, out triggerValue) && triggerValue;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDis))
            {
                lineRender.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
                lineRender.SetPosition(1, hit.point);

                if (hit.collider)
                {
                    Button buttonHit = hit.collider.gameObject.GetComponent<Button>();

                    if (buttonHit)
                    {
                        Image image = buttonHit.GetComponent<Image>();
                        image.color = Color.grey;

                        if (controllerInput)
                        {
                            buttonHit.GetComponent<Button>().onClick.Invoke();
                        }
                    }

                    else if (!buttonHit && selectedObject)
                    {
                        selectedObject.GetComponent<Image>().color = Color.white;
                        selectedObject = null;
                    }

                    Slider slideHit = hit.collider.gameObject.GetComponent<Slider>();

                    if (slideHit)
                    {
                        if (controllerInput)
                        {
                            if (triggerValue != lastState)
                            {
                                /*  if (slideHit.GetComponent<>(VolumeBar).background)
                                  {
                                      if (slideHit.value != maxMusicVol)
                                      {
                                          slideHit.value += increaseMusicValue;
                                      }

                                      else
                                      {
                                          slideHit.value = minMusicVol;
                                      }

                                  }

                                  else if (!slideHit.GetComponent<VolumeBar>().background)
                                  {
                                      if (slideHit.value != maxSFXVol)
                                      {
                                          slideHit.value += increaseSFXValue;
                                      }

                                      else
                                      {
                                          slideHit.value = minSFXVolume;
                                      }
                                  }

                                  triggerTime = Time.time; */
                            }
                        }
                    }

                }
            }

        }
    }
}
