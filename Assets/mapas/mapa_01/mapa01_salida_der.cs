using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.SceneManagement;

public class mapa01_salida_der : MonoBehaviour
{

    fade f;

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("player")){
            f = GameObject.FindGameObjectWithTag("GO_fade").GetComponent<fade>();
           // f.transicion_fade_in();
            SceneManager.LoadScene(1);
        }
    } 
}
