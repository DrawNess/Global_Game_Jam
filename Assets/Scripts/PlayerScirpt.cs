using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScirpt : MonoBehaviour
{
    private float hor;
    private float ver;
    public float speed = 2.0f;
    public int lives;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lives = 4;
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(hor * speed, ver * speed);

        if (hor < 0)
        {
            rb.transform.localScale = new Vector3(1, 1, 1);
            GetComponent<Animator>().Play("Left");
        }
        else if (hor > 0)
        {
            rb.transform.localScale = new Vector3(-1, 1, 1);
            GetComponent<Animator>().Play("Left");
        }
        else if (ver > 0)
        {
            GetComponent<Animator>().Play("Up");
        }
        else if (ver < 0)
        {
            GetComponent<Animator>().Play("Down");
        }
    }
}