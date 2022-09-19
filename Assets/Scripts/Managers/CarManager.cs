using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : CustomBehaviour
{

    [SerializeField] CarBehaviour _carBehaviour;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        _carBehaviour.Initialize(this);
    }
}
