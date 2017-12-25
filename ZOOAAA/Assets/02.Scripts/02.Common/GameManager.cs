using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    //public GameObject angleGauge;
    //Transform gaugeTransform;
    public float angleSize;
    float vectorX, vectorY;
    public Vector3 angleVector;
    public Slider powerGauge; // 슬라이더
    public GameObject angleGauge_Obj; // 앵글게이지
    public GameObject powerGauge_Obj; // 슬라이더 오브젝트 ( SetActive 때문에.. )
    public GameObject Body; // 임시 변수
    public Rigidbody2D bRB;
    public List<GameObject> _bodyList = new List<GameObject>();
    public List<GameObject> _Complete = new List<GameObject>();
    public GameObject[] animalPrefab = new GameObject[24];
    public int listIndex = 0;
    public int score = 0;
    public bool instanceLoad = false;
    public float completeValue = 0;
    public bool gameEnd = false;


    // Use this for initialization
    void Start () {
        bRB = Body.GetComponent<Rigidbody2D>();
        _bodyList.Add(Body);

        {
            GameObject temp;
            animalPrefab[16].transform.position = new Vector3(52f, -0.2188573f, 0);
            temp = Instantiate<GameObject>(animalPrefab[16]);
            _bodyList.Add(temp);
        }
        //gaugeTransform = angleGauge.transform;

        gameEnd = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (bRB.velocity == Vector2.zero)
        {
            powerGauge_Obj.transform.position = new Vector3(Body.transform.position.x + 2.5f, powerGauge_Obj.transform.position.y, 0f);
            angleGauge_Obj.transform.position = new Vector3(Body.transform.position.x - 7.5f, angleGauge_Obj.transform.position.y, angleGauge_Obj.transform.position.z);

            angleGauge_Obj.SetActive(true);
            powerGauge_Obj.SetActive(true);
        }
        else
        {
            powerGauge_Obj.SetActive(false);
            angleGauge_Obj.SetActive(false);
        }

        //_Complete[i].transform.position = new Vector3(10f, 10f, 10f);
        //Instantiate<GameObject>(_Complete[i]);


        //Debug.Log(angleSize);

        vectorX = -Mathf.Cos((-(angleSize - 180f) * 3.14f) / 180);
        vectorY = Mathf.Sin((-(angleSize - 180f) * 3.14f) / 180);
        angleVector = new Vector3(vectorX, vectorY ,0);

        //임시 변수 이용
        //Debug.Log(angleVector);
        if (instanceLoad == true) // Instance 생성
        {
            angleGauge_Obj.SetActive(true);
            powerGauge_Obj.SetActive(true);
            GameObject temp;
            if ((int)(listIndex & 1) == 1)
            {
                int tempPrefabNum = Random.Range(0, 12);
                animalPrefab[tempPrefabNum].transform.position = new Vector3(52f, -0.2188573f, 0);
                temp = Instantiate<GameObject>(animalPrefab[tempPrefabNum]);
            }
            else
            {
                int tempPrefabNum = Random.Range(12, 24);
                animalPrefab[tempPrefabNum].transform.position = new Vector3(52f, -0.2188573f, 0);
                temp = Instantiate<GameObject>(animalPrefab[tempPrefabNum]);
            }
            _bodyList.Add(temp);
            instanceLoad = false;
        }

        //powerGauge.transform.position = new Vector3(powerGauge.transform.position.x) // 2.5

    }
}
