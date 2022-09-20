using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using Game.Scripts.Managers;

namespace Game.Scripts.Behaviours
{

    public class CarBehaviour : MonoBehaviour
    {
        [SerializeField] float _speed;
        
        

        private CinemachinePath _currentPath;
        private CarManager _carManager;


        private float _currentDistanceOnPath;
        private bool _isGoing = true;
        private bool _carDetected = false;
        private bool _pathTaken = false;
        private bool _isQueueEnded = false;
        private int _pathId;
        private bool _isMyBarrierOpen;
        
        private barrierBehaviour _myBarrier;


        
        public void Initialize(CarManager carManager , int pathId)
        {
            
            _carManager = carManager;
            _carManager.GameManager.EventManager.OnBarrierOpened += MyBarrierOpened;
            _pathId = pathId;
            if (pathId == 0)
            {
                _currentPath = _carManager.GameManager.PathManager.LeftPath;
                _myBarrier = carManager.GameManager.BarrierManager._barrierBehaviours[0];
                
                
            }
            else
            {
                _currentPath = _carManager.GameManager.PathManager.RightPath;
                _myBarrier = carManager.GameManager.BarrierManager._barrierBehaviours[1];
                
            }
            _isMyBarrierOpen = false;
            if (_isGoing)
            {

                transform.DOMove(_currentPath.m_Waypoints[0].position + new Vector3(0f,0.35f,0f), 1).SetId(1).OnComplete(() => { _isQueueEnded = true; });
            }

        }

        void Update()
        {
            
            if (_currentPath != null && _isQueueEnded && _isMyBarrierOpen) 
            {

                transform.position = _currentPath.EvaluatePositionAtUnit(_currentDistanceOnPath, CinemachinePathBase.PositionUnits.Distance);
                transform.rotation = _currentPath.EvaluateOrientationAtUnit(_currentDistanceOnPath, CinemachinePathBase.PositionUnits.Distance);



                if (_isGoing)
                {
                    _currentDistanceOnPath += _speed * Time.deltaTime;
                }

                if (_currentDistanceOnPath > _currentPath.PathLength)
                {

                }
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 4f, Color.green);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4f))
            {
                if (hit.transform.CompareTag("car") && !_pathTaken)
                {
                    _carDetected = true;
                    _pathTaken = true;
                    StartCoroutine(pathTakenFalseCO());
                }

            }



        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("car"))
            {

                _isGoing = false;
                DOTween.Kill(1);
                

            }

        }

        private void OnTriggerStay(Collider other)
        {

            if (other.CompareTag("path") && _carDetected)
            {

                _currentPath = other.GetComponent<CinemachinePath>();
                _currentDistanceOnPath = 0;
                _isGoing = true;
                _carDetected = false;

            }
        }



        IEnumerator pathTakenFalseCO()
        {
            yield return new WaitForSeconds(1f);
            _pathTaken = false;
        }

        public void MyBarrierOpened(int id)
        {
            if (id == _pathId)
            {

            _isMyBarrierOpen = true;

            }
        }
        



    }
}
