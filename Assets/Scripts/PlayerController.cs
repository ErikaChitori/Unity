using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpforce;
    public Animator anim;
    public LayerMask ground;
    public Collider2D coll;
    public int Cherry;
    public int Diamond;
    public Text CherryNum;
    private bool isHurt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isHurt)
        Movement();
        SwitchAnim();
    }

    void Movement()
    {
        float HorizontalMove=Input.GetAxis("Horizontal");
        float facedirection=Input.GetAxisRaw("Horizontal");
        //移动
        if(HorizontalMove!=0)
        {
            rb.velocity=new Vector2(HorizontalMove*speed*Time.deltaTime,rb.velocity.y);
            anim.SetFloat("Running",Mathf.Abs(facedirection));
        }
        if(facedirection!=0)
        {
            transform.localScale=new Vector3(facedirection,1,1);
        }
        //跳跃
        if(Input.GetButtonDown("Jump")&&coll.IsTouchingLayers(ground))
        {
            rb.velocity=new Vector2(rb.velocity.x,jumpforce*Time.deltaTime);
            anim.SetBool("Jumping",true);
        }

    }
    void SwitchAnim()
    {
        anim.SetBool("Idle",false);
        if(rb.velocity.y<0.1f&&!coll.IsTouchingLayers(ground))
        {
            anim.SetBool("Falling",true);
        }
        if(anim.GetBool("Jumping"))
        {
            if(rb.velocity.y<0)
            {
                anim.SetBool("Jumping",false);
                anim.SetBool("Falling",true);
            }
        }
        else if(isHurt)
        {
            anim.SetBool("Hurting",true);
            if(Mathf.Abs(rb.velocity.x)<0.1f)
            {
                anim.SetBool("Hurting",false);
                anim.SetBool("Idle",true);
                isHurt=false;
            }
        }
        else if(coll.IsTouchingLayers(ground))
        {
            anim.SetBool("Falling",false);
            anim.SetBool("Idle",true);
        }
    }
    //物品收集
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Collection")
        {
            Destroy(other.gameObject);
            Cherry+=1;
            CherryNum.text=Cherry.ToString();
        }
        if(other.tag=="Collection2")
        {
            Destroy(other.gameObject);
            Diamond+=1;
        }
    }
    //消灭敌人
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Enemy")
        {
            Enemy enemy=other.gameObject.GetComponent<Enemy>();
            if(anim.GetBool("Falling"))
            {
                enemy.JumpOn();
                rb.velocity=new Vector2(rb.velocity.x,jumpforce*Time.deltaTime);
                anim.SetBool("Jumping",true);
            }else if(transform.position.x<other.gameObject.transform.position.x)
            {
                rb.velocity=new Vector2(-20,rb.velocity.y);
                isHurt=true;
            }
            else if(transform.position.x>other.gameObject.transform.position.x)
            {
                rb.velocity=new Vector2(20,rb.velocity.y);
                isHurt=true;
            }
        }
    }
}
