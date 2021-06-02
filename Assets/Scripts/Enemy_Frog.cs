using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Frog : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public Transform LeftPoint,RightPoint;
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();   
    }
    void Movement()
    {

    }
}
