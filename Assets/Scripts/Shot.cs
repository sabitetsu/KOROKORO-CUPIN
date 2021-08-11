using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShotBall()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, 0, ForceMode.Impulse);
    }
}
