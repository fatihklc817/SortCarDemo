using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviouur : MonoBehaviour
{
    private ButtonManager _buttonManager;
   
  
    public void Initialize(ButtonManager buttonManager)
    {
        _buttonManager = buttonManager;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.CompareTag("Button") && !_buttonManager.GameManager.BarrierManager.IsBarrierInAction) 
                {
                    Debug.Log("KapiAçilsin");
                    _buttonManager.GameManager.BarrierManager.OpenBarrier();
                }
            }
        }


    }



}
