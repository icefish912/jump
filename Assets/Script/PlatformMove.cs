using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform PosA,PosB;
    private Transform MovePos;
    [SerializeField] private float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        MovePos=PosA;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, PosA.position) < 0.1f)
        {
            MovePos=PosB;
        }
        if (Vector2.Distance(transform.position, PosB.position) < 0.1f)
        {
            MovePos=PosA;
        }
        transform.position = Vector2.MoveTowards(transform.position,MovePos.position,MoveSpeed*Time.deltaTime);
    }
}
