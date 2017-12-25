using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleField : MonoBehaviour {

    Transform tr;
    Transform gm;
	// Use this for initialization
	void Start () {
        tr = this.transform;
        gm = GameManager.Instance.Body.transform;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("X = " + GameManager.Instance.Body.transform.position.x);
        //tr.position = new Vector3(gm.position.x - 7.5f, tr.position.y, tr.position.z);
	}
}
