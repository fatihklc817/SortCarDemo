using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : CustomBehaviour
{

    [SerializeField] ButtonBehaviouur _buttonBehaviour;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        _buttonBehaviour.Initialize(this);
    }

    

}
