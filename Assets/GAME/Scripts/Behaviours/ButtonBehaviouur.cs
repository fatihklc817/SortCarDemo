using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Behaviours
{

    public class ButtonBehaviouur : MonoBehaviour
    {
        [SerializeField] private ButtonManager _buttonManager;
        [SerializeField] private int _buttonID;

        public int ButtonID => _buttonID;
        

        public void Initialize(ButtonManager buttonManager)
        {
            _buttonManager = buttonManager;
        }

    }
}
