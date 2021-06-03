using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Frog : Enemy
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    //private Animator anim;
    private Collider2D coll;
    public LayerMask ground;
    public Transform LeftPoint,RightPoint;
    public float Speed,JumpForce;
    public float Leftx,Rightx;
    private bool Faceleft=true;
    protected override void Start()
    {
        base.Start();
        rb=GetComponent<Rigidbody2D>();
        //anim=GetComponent<Animator>();
        coll=GetComponent<Collider2D>();
        transform.DetachChildren();
        Leftx=LeftPoint.position.x;
        Rightx=RightPoint.position.x;
        Destroy(LeftPoint.gameObject);
        Destroy(RightPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchAnim();
    }
    void Movement()
    {
        if(Faceleft)
        {
            if(coll.IsTouchingLayers(ground))
            {     
                anim.SetBool("Jumping",true);      
                 rb.velocity=new Vector2(-Speed,JumpForce);
            }            
            if(transform.position.x<Leftx)
            {
                rb.velocity=new Vector2(0,0);
                transform.localScale=new Vector3(-1,1,1);
                Faceleft=false;
            }
        }
        else{
            if(coll.IsTouchingLayers(ground))
            {     
                anim.SetBool("Jumping",true);      
                 rb.velocity=new Vector2(Speed,JumpForce);
            }  
            if(transform.position.x>Rightx)
            {
                rb.velocity=new Vector2(0,0);
                transform.localScale=new Vector3(1,1,1);
                Faceleft=true;
            }
        }
    }
    void SwitchAnim()
    {
        if(anim.GetBool("Jumping"))
        {
            if(rb.velocity.y<0.1f)
            {
                anim.SetBool("Jumping",false);
                anim.SetBool("Falling",true);
            }
        }
        if(coll.IsTouchingLayers(ground)&&anim.GetBool("Falling"))
        {
            anim.SetBool("Falling",false);
        }
    }
   
}
