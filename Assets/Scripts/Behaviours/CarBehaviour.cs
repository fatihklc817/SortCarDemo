using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CarBehaviour : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] CinemachinePath _currentPath;

    private CarManager _carManager;

    private float _currentDistanceOnPath;
    private bool _isGoing = true;
    private bool _carDetected = false;
    private bool _pathTaken = false;
    

    public void Initialize(CarManager carManager)
    {
        _carManager = carManager;
    }
    
    void Update()
    {
           if (_currentPath != null)
           {
                
                    transform.position= _currentPath.EvaluatePositionAtUnit(_currentDistanceOnPath,CinemachinePathBase.PositionUnits.Distance);
                    transform.rotation = _currentPath.EvaluateOrientationAtUnit(_currentDistanceOnPath, CinemachinePathBase.PositionUnits.Distance);
                    
                

                if (_isGoing)
                {
                    _currentDistanceOnPath += _speed * Time.deltaTime;
                }

                if (_currentDistanceOnPath > _currentPath.PathLength)
                {
            
                }
           }
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5f, Color.green);
             RaycastHit hit;
             if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f))
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

}
