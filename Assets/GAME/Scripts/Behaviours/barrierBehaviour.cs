using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Game.Scripts.Managers;

namespace Game.Scripts.Behaviours
{

    public class barrierBehaviour : MonoBehaviour
    {
        public bool IsBarrierOn;
        public bool IsBarrierInAction;

        [SerializeField] Transform _pivotPoint;
        [SerializeField] float _doorCloseTime;
        private BarrierManager _barrierManager;


        // Start is called before the first frame update

        public void Initialize(BarrierManager barrierManager)
        {
            _barrierManager = barrierManager;

        }




        private void Update()
        {
            if (IsBarrierOn)
            {
                if (transform.rotation.eulerAngles.z < 90)
                {

                    transform.RotateAround(_pivotPoint.position, Vector3.forward, 90f * Time.deltaTime);

                }
            }
            else if (!IsBarrierOn)
            {
                if (transform.rotation.eulerAngles.z > 0f)
                {
                    transform.RotateAround(_pivotPoint.position, Vector3.back, 90f * Time.deltaTime);
                    if (transform.rotation.z < 0f)
                    {
                        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                       IsBarrierInAction = false;
                        Debug.Log("as");


                    }
                }
            }
        }

        public void OpenBarrier()
        {
            StartCoroutine(OpenBarierCO());
        }


        IEnumerator OpenBarierCO()
        {
            IsBarrierInAction = true;
            IsBarrierOn = true;
            yield return new WaitForSeconds(_doorCloseTime);
            IsBarrierOn = false;

        }

    }
}