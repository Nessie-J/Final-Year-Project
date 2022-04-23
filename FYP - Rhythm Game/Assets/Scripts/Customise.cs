using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using controller;

public class Customise : MonoBehaviour
{
    [SerializeField] private Material newMaterial;
    [SerializeField] private int materialID;
    public LayerMask handsLayer;

    public MeshRenderer leftHand;
    public MeshRenderer rightHand;
    void Awake()
    {
        PlayerPrefs.GetInt("newMaterial", materialID);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        //Collision with player hands
        //Change player hands material to x material


        leftHand.material = newMaterial;
        rightHand.material = newMaterial;

        PlayerPrefs.SetInt("newMaterial", materialID);
    }

    private void SetItem()
    {
       
    }
}
