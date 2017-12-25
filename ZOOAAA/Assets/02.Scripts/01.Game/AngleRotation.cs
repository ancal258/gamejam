using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleRotation : MonoBehaviour {

    public GameObject obj;
    GameManager _GameManager;
    Transform _transform;
    Vector3 rotateZ;
    float rotateSum = 0;
    // bool angleSize = false;
    bool angleSize = false;
    // Use this for initialization
    void Start () {
        _transform = this.transform;
        rotateZ = new Vector3(0, 0, 1);
        _GameManager = GameManager.Instance;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            //_transform.position = new Vector3(_GameManager.Body.transform.position.x - 1.05f, _transform.position.y, _transform.position.z);
            GetForceAngles();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _GameManager.angleSize = _transform.rotation.eulerAngles.z - 180f;
            //_transform.RotateAround(obj.transform.position, rotateZ, -rotateSum);  // 각도 원래대로
        }
    }



    void GetForceAngles()
    {
        if (angleSize == false)
        {
            _transform.RotateAround(obj.transform.position, rotateZ, -1f);
            rotateSum -= 1f;
        }
        else
        {
            _transform.RotateAround(obj.transform.position, rotateZ, 1f);
            rotateSum += 1f;
        }

        if (_transform.rotation.eulerAngles.z - 180f <= 90 && _transform.rotation.eulerAngles.z - 180f > 0)
        {
            angleSize = true;
        }
        else if (_transform.rotation.eulerAngles.z - 180f <= 0)
        {
            angleSize = false;
        }
    }
}
