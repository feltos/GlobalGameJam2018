using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaAxe : MonoBehaviour
{
    [SerializeField]
    GameObject axePivot;
    bool right = true;

    private void Update()
    {
        RotationAxe();
    }

    void RotationAxe()
    {
        if(right)
        {
            transform.RotateAround(axePivot.transform.position, Vector3.forward, 180 * Time.deltaTime);
            if (transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z <= 270)
            {
                right = false;
            }
        }

        if(!right)
        {
            transform.RotateAround(axePivot.transform.position, Vector3.back, 180 * Time.deltaTime);
            if(transform.rotation.eulerAngles.z <= 270 && transform.rotation.eulerAngles.z >= 90)
            {
                right = true;
            }
        }   
    }

}
