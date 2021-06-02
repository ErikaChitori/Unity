using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    public float Speed,Jumpforce;
    public Transform GroundCheck;
    public LayerMask ground;
    public bool isGround,isJump;
    public bool jumpPressed;
    public int jumpCount;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        coll=GetComponent<Collider2D>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")&&jumpCount>0)
        {
            jumpPressed=true;
        }

    }
    private void FixedUpdate() 
    {
        
    }
    void GroundMovement()
    {
        float horizontalMove=Input.GetAxis("Horizontal");
        
    }
}
 