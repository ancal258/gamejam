using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.gameEnd == true)
        {
            this.transform.position = new Vector3(-9.8f, 7.5f- 300f, -21);
        }

	}
}
