using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Vector3 startPos;
    Vector3 nowPos;
    Vector3 endPos;
    GameObject LineObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //startPos = Input.mousePosition;
            startPos = new Vector3(0, 1, 0);
            TargetLine(startPos, startPos);
            Debug.Log("START");
        }
        else if (Input.GetMouseButton(0))
        {
            

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50.0f))
            {
                if (hit.collider.gameObject.tag != "Out")
                {
                    nowPos = hit.point;
                    nowPos.y = 1;
                    Destroy(LineObj);
                    TargetLine(startPos, nowPos);
                    Debug.Log("NOW");
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            //endPos.y = 1;
            Destroy(LineObj);
            TargetLine(startPos, nowPos);
            Debug.Log("END");
        }
    }

    void ShotBall()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 0, ForceMode.Impulse);
    }

    void TargetLine(Vector3 startVec, Vector3 endVec)
    {

        LineObj = new GameObject("Line");
        LineRenderer lRend = LineObj.AddComponent<LineRenderer>();
        lRend.positionCount = 2;
        lRend.startWidth = 0.5f;
        lRend.endWidth = 0.5f;
        //Vector3 startVec = new Vector3(-10.0f, 10.0f, 0.0f);
        //Vector3 endVec = new Vector3(0.0f, 0.0f, 0.0f);
        lRend.SetPosition(0, startVec);
        lRend.SetPosition(1, endVec);
    }
}
