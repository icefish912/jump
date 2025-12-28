using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private Animator anim;
    private Vector2 pos;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        pos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("traps"))
        {
            PlayerMove move = GetComponent<PlayerMove>();
            if (move != null)
            {
                move.enabled = false;
            }
           anim.SetTrigger("isDead"); 
           rb.bodyType=RigidbodyType2D.Static;
        }
    }

    public void Revive()
    {
        transform.position=pos;
        rb.bodyType=RigidbodyType2D.Dynamic;
        anim.ResetTrigger("isDead");
        anim.SetTrigger("Revive");
        PlayerMove move = GetComponent<PlayerMove>();
        if (move != null)
        {
            move.enabled = true;
        }
    }
}