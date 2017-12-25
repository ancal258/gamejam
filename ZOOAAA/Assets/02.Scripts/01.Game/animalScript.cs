using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class animalScript : MonoBehaviour
{
    public int state;
    bool checkY;

    public float prePositionY = 0;
    int localNumber = 0;
    bool prevOn = false;
    float rotateStack = 0;
    Transform tr;
    int prevIndex;
    bool tweenDo = false;
    // Use this for initialization
    void Start()
    {
        tr = this.transform;
        state = 1;
        prevIndex = GameManager.Instance.listIndex;
    }
    // Update is called once per frame
    void Update()
    {
        if (state == 1) // Prev
        {
            tr.Rotate(0, 2f, 0);
            rotateStack += 2f;
            if (prevIndex < GameManager.Instance.listIndex) //하나가 종착역에 도착하면 // 키코드 O는 임시...
            {
                tr.position = new Vector3(7.5f, -3.812193f, 0);
                tr.Rotate(0, -rotateStack, 0);
            }
            if (tr.position.x < 8)
                state = 2;
        }
        else if (state == 4) // Cur
        {

            if (tr.position.x >= -32.5f)
            {
                if (tr.transform.position.y >= prePositionY + 0.4f)
                    checkY = false;
                if (tr.transform.position.y <= prePositionY)
                    checkY = true;

                if (checkY == true)
                    tr.transform.position = new Vector3(tr.transform.position.x - 0.1f, tr.transform.position.y + (0.1f * 1), tr.transform.position.z);
                else
                    tr.transform.position = new Vector3(tr.transform.position.x - 0.1f, tr.transform.position.y + (0.1f * -1), tr.transform.position.z);
            }
            else
            {
                tr.transform.position = new Vector3(tr.transform.position.x - GameManager.Instance.completeValue, tr.transform.position.y - 300f, tr.transform.position.z);
                //tr.Rotate(0f, 180f, 0f);
                GameManager.Instance.completeValue += 5.0f;
                state = 5;
            }

            //if() 종착역에 도착 하면 -> 없애버리고 점수를 주던... 터트려 버리건 ...?? 
        }
        else if (state == 5)
        {
            if(GameManager.Instance.gameEnd == true)
            {
                prePositionY = tr.transform.position.y;
                state = 6;
            }
        }
        else if (state == 6) // 엔딩 조건 주기
        {

            if (tr.position.x <= 100.5f)
            {

                if (tr.transform.position.y >= prePositionY + 0.4f)
                    checkY = false;
                if (tr.transform.position.y <= prePositionY)
                    checkY = true;

                if (checkY == true)
                    tr.transform.position = new Vector3(tr.transform.position.x + 0.1f, tr.transform.position.y + (0.1f * 1), tr.transform.position.z);
                else
                    tr.transform.position = new Vector3(tr.transform.position.x + 0.1f, tr.transform.position.y + (0.1f * -1), tr.transform.position.z);
            }

        }
    }
}
