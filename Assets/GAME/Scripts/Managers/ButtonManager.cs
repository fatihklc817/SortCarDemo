using Game.Scripts.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{

    public class ButtonManager : CustomBehaviour
    {

        [SerializeField] List<ButtonBehaviouur> _buttonBehaviours;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);


        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    if (hit.transform.CompareTag("Button") && !GameManager.BarrierManager.IsBarrierInAction)
                    {
                        Debug.Log("KapiAçilsin");
                        GameManager.BarrierManager.OpenBarrier(hit.transform.gameObject.GetComponent<ButtonBehaviouur>().ButtonID);

                    }
                }
            }
        }


    }
}