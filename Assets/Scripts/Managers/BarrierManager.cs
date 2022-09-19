using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierManager : CustomBehaviour
{
    [SerializeField] barrierBehaviour _barrierBehaviour;

    public bool IsBarrierInAction;
    

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        _barrierBehaviour.Initialize(this);
    }

    public void OpenBarrier()
    {
        _barrierBehaviour.OpenBarrier();
    }


    
}
