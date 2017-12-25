using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvent : MonoBehaviour {

    //[SerializeField]private BezierCurve bezier;

    private float fGage = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Vector3.zero);
        //transform.position = bezier.GetPointAt(fGage += 1.0f/10.0f * Time.deltaTime);
	}
}
