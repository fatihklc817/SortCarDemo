using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Game.Scripts.Managers
{
    public class PathManager : CustomBehaviour
    {

        public CinemachinePath LeftPath;
        public CinemachinePath RightPath;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
        }


    }
}
