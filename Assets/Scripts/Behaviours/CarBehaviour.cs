using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CarBehaviour : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] CinemachineSmoothPath _currentPath;
    private float _currentDistanceOnPath;
    private bool _isGoing = true;
    private bool _pathChanged=true;
    
    void Update()
    {
           if (_currentPath != null)
           {
                if (_pathChanged)
                {
                    transform.position= _currentPath.EvaluatePositionAtUnit(_currentDistanceOnPath,CinemachinePathBase.PositionUnits.Distance);
                    transform.rotation = _currentPath.EvaluateOrientationAtUnit(_currentDistanceOnPath, CinemachinePathBase.PositionUnits.Distance);
                    _pathChanged = false;
                }

                if (_isGoing)
                {
                    _currentDistanceOnPath += _speed * Time.deltaTime;
                }

                if (_currentDistanceOnPath > _currentPath.PathLength)
                {
            
                }
           }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("car"))
        {
             
        _isGoing = false;
            
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("path") && !_isGoing)
        {
            
            _currentPath = other.GetComponent<CinemachineSmoothPath>();
            

            transform.DORotate(_currentPath.m_Waypoints[0].position,0.5f);
            transform.DOMove(_currentPath.m_Waypoints[0].position,0.5f).OnComplete(()=> {
                _currentDistanceOnPath = 0;
                _pathChanged = true;
                _isGoing = true;
            });


            
        }
    }
}
