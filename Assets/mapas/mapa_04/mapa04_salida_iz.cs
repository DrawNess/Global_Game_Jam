using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mapa04_salida_iz : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("player")){
            SceneManager.LoadScene(2);
        }
    } 
}
