using Game.Scripts.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{

    public class BarrierManager : CustomBehaviour
    {
        [SerializeField] barrierBehaviour[] _barrierBehaviours;

        public bool IsBarrierInAction;


        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            for (int i = 0; i < _barrierBehaviours.Length; i++)
            {
                _barrierBehaviours[i].Initialize(this);

            }
        }

        public void OpenBarrier(int ButtonID)
        {
            _barrierBehaviours[ButtonID].OpenBarrier();

        }



    }
}
