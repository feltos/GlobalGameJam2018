using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotativeBoule : MonoBehaviour
{
    [SerializeField]
    GameObject ball_pivot;
    
    void Start ()
    {
		
	}
	
	void Update ()
    {
        this.transform.RotateAround(ball_pivot.transform.position, Vector3.forward, 360 * Time.deltaTime);
    }
}
