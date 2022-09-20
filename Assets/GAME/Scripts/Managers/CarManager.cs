using Game.Scripts.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{


    public class CarManager : CustomBehaviour
    {
        [SerializeField] CarBehaviour _carPrefabLeft;
        [SerializeField] CarBehaviour _carPrefabRight;
        [SerializeField] Transform _leftInstantiatePos;
        [SerializeField] Transform _rightInstantiatePos;
        private CarBehaviour _currentCar;



        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            var car1 = Instantiate(_carPrefabLeft, _leftInstantiatePos.position, Quaternion.Euler(0f, 180f, 0f), _leftInstantiatePos.parent);
            var car2 = Instantiate(_carPrefabRight, _rightInstantiatePos.position, Quaternion.Euler(0f, 180f, 0f), _rightInstantiatePos.parent);
            car1.Initialize(this, 0);
            car2.Initialize(this, 1);
        }


        public void InstantiateCar(int id)
        {
            
            if (id == 0)
            {
                 _currentCar = Instantiate(_carPrefabLeft , _leftInstantiatePos.position, Quaternion.Euler(0f,180f,0f), _leftInstantiatePos.parent);
            }
            else
            {
                 _currentCar = Instantiate(_carPrefabRight, _rightInstantiatePos.position, Quaternion.Euler(0f, 180f, 0f), _rightInstantiatePos.parent);
            }

            _currentCar.Initialize(this,id);
 
            
        }

        


    }
}