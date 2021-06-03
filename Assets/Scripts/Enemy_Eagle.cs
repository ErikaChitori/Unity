using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Eagle : Enemy
{
    private Rigidbody2D rb;
    //private Animator anim;
    private Collider2D coll;
    public Transform UpPoint,DownPoint;
    public float Speed;
    public float Upy,Downy;
    public bool isUp=true;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb=GetComponent<Rigidbody2D>();
        coll=GetComponent<Collider2D>();
        transform.DetachChildren();
        Upy=UpPoint.position.y;
        Downy=DownPoint.position.y;
        Destroy(UpPoint.gameObject);
        Destroy(DownPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if(isUp)
        {
            rb.velocity=new Vector2(0,Speed);
            if(transform.position.y>Upy)
            {
                isUp=false;
            }
        }
        else{
            rb.velocity=new Vector2(0,-Speed);
            if(transform.position.y<Downy){
                isUp=true;
            }
        }
    }

}
