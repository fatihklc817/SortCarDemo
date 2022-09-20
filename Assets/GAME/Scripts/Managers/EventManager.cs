using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class EventManager : CustomBehaviour
    {

        public event Action<int> OnBarrierOpened;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
        }

        public void OpenBarrier(int barrierID)
        {
            OnBarrierOpened?.Invoke(barrierID);
        }
        
    }
}
