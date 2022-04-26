using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI {
    public class Buttons : MonoBehaviour
    {
        [Header("Layer Mask")]
        public LayerMask handsLayer;

        [Header("Compoents")]
        public Button button;
        public AudioSource audioSource;

        private void Start()
        {
            button = GetComponent<Button>();
            audioSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if ((handsLayer.value & (1 << collision.gameObject.layer)) > 0)
            {
                button.onClick.Invoke();
                audioSource.Play();
            }


        }
    }
}
