using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        fade_out();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void fade_in(){
        animator.Play("fade_in");
    }
    public void fade_out(){
        animator.Play("fade_out");
    }


    public IEnumerator transicion_fade_in(){
        fade_in();
        yield return new WaitForSeconds(1f);
    }
}
