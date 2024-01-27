using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrPlayeremov : MonoBehaviour
{
    [Range(0.1f,10f)]public float vel;
    public Vector2 dir;
    public float hm, vm;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hm=Input.GetAxis("Horizontal");
        vm=Input.GetAxis("Vertical");
        dir= new Vector2(hm, vm);
        rb.MovePosition(rb.position + dir * vel * Time.deltaTime);
    }
}
