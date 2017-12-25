using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headJudgment : MonoBehaviour
{
    GameManager gm;
    jumpAddForce AF;
    public Transform tr_mybody;
    bool getMyBody = false;
    void Update()
    {
        gm = GameManager.Instance;
        AF = this.GetComponent<jumpAddForce>();
    }

    void OnCollisionEnter2D(Collision2D c)
    {

        if (c.transform.CompareTag("body"))
        {
            //Debug.Log("Euler = " + );

            if (transform.localRotation.z >= 360.0f)
                transform.localRotation = Quaternion.Euler(0, 0, (int)(Mathf.Round(transform.localEulerAngles.z)) % 360);

            if (transform.localRotation.z <= 0.0f)
                transform.localRotation = Quaternion.Euler(0, 0, (int)(Mathf.Round(transform.localEulerAngles.z)) % 360);

            //Debug.Log((int)(Mathf.Round(transform.localEulerAngles.z)) % 360);// (0, 0, transform.localRotation.z - 180));
            //Debug.Log("dd" + transform.localEulerAngles.z);
            transform.parent = c.gameObject.transform;
            GetComponent<Rigidbody2D>().simulated = false;
            c.gameObject.GetComponent<Rigidbody2D>().simulated = false;

            if (transform.localPosition.x <= -0.25f)
                gm.score += 150;
            else if (transform.localPosition.x > -0.25f && transform.localPosition.x <= -0.15f)
                gm.score += 125;
            else if (transform.localPosition.x > -0.15f && transform.localPosition.x <= 0.1f)
                gm.score += 100;
            else if (transform.localPosition.x > 0.11f && transform.localPosition.x <= 0.3f)
                gm.score += 75;
            else if (transform.localPosition.x > 0.3f && transform.localPosition.x <= 0.45f)
                gm.score += 50;

            if (transform.localEulerAngles.z >= 0.0f && transform.localEulerAngles.z < 90.0f)
                gm.score += 150;
            else if (transform.localEulerAngles.z >= 90.0f && transform.localEulerAngles.z < 180.0f)
                gm.score += 125;
            else if (transform.localEulerAngles.z >= 180.0f && transform.localEulerAngles.z < 270.0f)
                gm.score += 100;
            else if (transform.localEulerAngles.z >= 270.0f && transform.localEulerAngles.z < 360.0f)
                gm.score += 75;


            gm._Complete.Add(gameObject);
            c.transform.GetComponent<animalScript>().state = 4;
            c.transform.GetComponent<animalScript>().prePositionY = c.transform.position.y;
            //Debug.Log("Score = " + GameManager.Instance.score);
            //붙어도 다음 처리
            if (AF.colOn == false)
            {
                gm.listIndex++;
                //Debug.Log("gm list " + gm.listIndex);
                gm.bRB = gm._bodyList[gm.listIndex].GetComponent<Rigidbody2D>();
                gm.Body = gm._bodyList[gm.listIndex];
                gm.instanceLoad = true;
                //gm._bodyList.RemoveAt(0);
                AF.anim.state = 3;
                AF.colOn = true;
            }


        }

    }
}