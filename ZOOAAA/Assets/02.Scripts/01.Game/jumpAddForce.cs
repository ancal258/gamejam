using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class jumpAddForce : MonoBehaviour
{

    bool isButton;
    public float maxforce = 500f;

    public float addForce;
    bool plusForce;
    bool minusForce;
    Rigidbody2D rg;
    GameManager gm;
    public animalScript anim;
    int jumpState;
    //시간 관련
    int timeFrame;
    int moveTime;
    bool time; // 켜져 있을 때 남은 시간이 가지 않게 
    public bool colOn = false;
    bool oneTimesCol = false;
    public Transform obj;
    GameManager _GameManager;
    public Transform _transform;
    Vector3 rotateZ;
    float rotateSum = 0;
    // bool angleSize = false;
    bool angleSize = false;
    //public GameObject Angle;

    public bool isAngle;
    public bool isAddforce;

    public float torque;

    public AudioClip JumpSound;
    private AudioSource audio;

    void Start()
    {
        isButton = false;
        plusForce = false;
        minusForce = false;
        rg = GetComponent<Rigidbody2D>();
        gm = GameManager.Instance;
        anim = this.GetComponent<animalScript>();
        time = false;
        jumpState = 1;

        //Angle = GameObject.Find("AngleGauge").GetComponent<GameObject>();
        //if (gm.bRB.velocity == Vector2.zero)
        _transform = GameObject.Find("AngleGauge").GetComponent<Transform>();
        obj = GameObject.Find("AngleCube").GetComponent<Transform>();
        rotateZ = new Vector3(0, 0, 1);
        _GameManager = GameManager.Instance;

        isAddforce = false;
        isAngle = true;


        audio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (_GameManager.gameEnd == false)
        {
            if (rg.velocity == Vector2.zero && jumpState != 1)
            {
                addForce = 0;
                jumpState = 1;
                isButton = false;
                plusForce = false;
                minusForce = false;
                isAngle = true;
                isAddforce = false;
            }

            if (isAddforce)
            {

                if (anim.state == 2)
                {
                    if (plusForce)
                        addForce += maxforce * Time.deltaTime;

                    if (minusForce)
                        addForce -= maxforce * Time.deltaTime;

                    if (jumpState == 0)
                    {
                        addForce = -2;
                        isButton = false;


                    }

                    if ((isButton && addForce != 2))
                    {

                        if (addForce <= 0.0f)
                        {

                            plusForce = true;
                            minusForce = false;

                        }

                        if (addForce >= maxforce)
                        {

                            plusForce = false;
                            minusForce = true;

                        }


                    }

                    //if (moveTime >= 11)
                    //{

                    //    isButton = false;
                    //    addForce = 0;
                    //    isButton = false;

                    //}

                    //if (time && timeFrame % 40 == 0)
                    //{

                    //    moveTime += 1;

                    //}

                    if (isButton && time)
                        timeFrame++;

                    if (transform.position.y >= -3.7f)
                    {

                        isButton = false;

                    }

                    if (moveTime == 11)
                        time = false;


                    if (Input.GetMouseButton(0))
                    {

                        isButton = true;
                        gm.powerGauge.maxValue = maxforce;
                        gm.powerGauge.value = addForce; //7.4687


                        if (moveTime < 11)
                            time = true;



                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        jumpState = 0;

                        gm.powerGauge.value = 0;
                        plusForce = false;
                        minusForce = false;
                        if (addForce != -2)
                        {
                            //Debug.Log(GameManager.Instance.angleVector);
                            rg.AddForce(gm.angleVector * addForce);
                            rg.AddTorque(addForce / 5);
                            if (JumpSound != null)
                                audio.PlayOneShot(JumpSound);
                        }

                        time = false;
                        moveTime = 0;
                        timeFrame = 0;
                        isAngle = true;
                        isAddforce = false;
                    }
                }
            }

            if (isAngle)
            {
                if (anim.state == 2)
                {
                    if (Input.GetMouseButton(0))
                    {
                        //_transform.position = new Vector3(_GameManager.Body.transform.position.x - 1.05f, _transform.position.y, _transform.position.z);
                        GetForceAngles();
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        _GameManager.angleSize = _transform.rotation.eulerAngles.z - 180f;
                        //         jumpAddForce.addForceOn = true;
                        isAngle = false;
                        isAddforce = true;
                    }
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.transform.CompareTag("Arrive") && this.transform.CompareTag("body"))
        {

            //Debug.Log("Enter!!");
            //Debug.Log("COL!!");
            if (colOn == false)
            {
                gm.listIndex++;
                //Debug.Log("gm list " + gm.listIndex);
                gm.bRB = gm._bodyList[gm.listIndex].GetComponent<Rigidbody2D>();
                gm.Body = gm._bodyList[gm.listIndex];
                gm.instanceLoad = true;
                //gm._bodyList.RemoveAt(0);
                anim.state = 3;
                //gm._bodyList.RemoveAt(0);
                //Destroy(gameObject);

                colOn = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.transform.CompareTag("Ground") && rg.velocity == Vector2.zero)
        {
            //Debug.Log("Check!!!!");
            addForce = 0;
            jumpState = 1;
            //_transform.rotation = new Quaternion(0, 0, 0, 0);
            isButton = false;
            plusForce = false;
            minusForce = false;
            isAngle = true;
            isAddforce = false;
        }



    }
    public float GetForce()
    {
        return addForce;
    }


    void GetForceAngles()
    {
        if (angleSize == false)
        {
            _transform.RotateAround(obj.position, rotateZ, -90f * Time.deltaTime);
            rotateSum -= 2f;
        }
        else
        {
            _transform.RotateAround(obj.position, rotateZ, 90f * Time.deltaTime);
            rotateSum += 2f;
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