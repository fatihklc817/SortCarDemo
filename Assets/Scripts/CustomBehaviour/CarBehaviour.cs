using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarBehaviour : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] CinemachineSmoothPath _path1;
    private float _distanceOnPath;


    void Update()
    {
            transform.position= _path1.EvaluatePositionAtUnit(_distanceOnPath,CinemachinePathBase.PositionUnits.Distance);
              transform.rotation = _path1.EvaluateOrientationAtUnit(_distanceOnPath, CinemachinePathBase.PositionUnits.Distance);
            _distanceOnPath += _speed * Time.deltaTime;

        if (_distanceOnPath > _path1.PathLength)
        {
            
        }
    }
}
