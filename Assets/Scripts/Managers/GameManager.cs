using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : CustomBehaviour
{

    //public heelManager HeelManager;
    public BarrierManager BarrierManager;
    public CarManager CarManager;
    public ButtonManager ButtonManager;

    public void Awake()
    {
        //HeelManager.Initialize(this);
        BarrierManager.Initialize(this);
        CarManager.Initialize(this);
        ButtonManager.Initialize(this);
    }


}
