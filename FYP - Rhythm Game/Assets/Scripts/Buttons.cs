using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public LayerMask handsLayer;

    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if ((handsLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            button.onClick.Invoke();
        }

          
    }
}
