using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private  Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float isGroundCheckLine;
    [SerializeField] private LayerMask GroundLayer;
    private bool isGround;
    private bool isJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        AnimatorController();

        isGroundCheck();
    }

    private void isGroundCheck()
    {
        isGround = Physics2D.Raycast(transform.position, Vector2.down,isGroundCheckLine,GroundLayer);
    }
        
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position,new Vector2(transform.position.x,transform.position.y-isGroundCheckLine));
    }

    private void Jump()
    {
         if(Input.GetButtonDown("Jump") && isGround)
            rb.velocity=new Vector2(rb.velocity.x,jumpSpeed);
    }

    private void AnimatorController()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale=new Vector2(1,1);
        }
        if (rb.velocity.x < 0)
        {
            transform.localScale=new Vector2(-1,1);
        }
        if (rb.velocity.y > 0.3f)
        {
            isJump=true;
        }
        else
        {
            isJump=false;
        }
        anim.SetBool("isJump",isJump);
        anim.SetBool("isGround",isGround);
    }
}
