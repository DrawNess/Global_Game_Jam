using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mapa02_salida_der : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("player")){
            SceneManager.LoadScene(2);
        }
    } 
}
