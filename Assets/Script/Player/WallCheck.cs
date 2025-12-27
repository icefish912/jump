  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public bool inWall;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("inWall",inWall);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            inWall=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            inWall=false;
        }
    }
}
