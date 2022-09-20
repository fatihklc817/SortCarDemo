using Game.Scripts.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{

    public class ButtonManager : CustomBehaviour
    {

        public List<ButtonBehaviouur> _buttonBehaviours;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            for (int i = 0; i < _buttonBehaviours.Count; i++)
            {
                _buttonBehaviours[i].Initialize(this);
            }

        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    if (hit.transform.CompareTag("Button"))
                    {
                        Debug.Log("KapiAçilsin");
                        int id = hit.transform.gameObject.GetComponent<ButtonBehaviouur>().ButtonID;
                        GameManager.BarrierManager.OpenBarrier(id);
                        GameManager.EventManager.OpenBarrier(id);


                        

                    }
                }
            }
        }


    }
}