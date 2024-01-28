using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
     public float speed = 500f; // Velocidad de movimiento del jugador

    void Update()
    {
        // Obtener las entradas del usuario
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;

        // Aplicar el movimiento al jugador
        transform.Translate(movement);


    }

      void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("puerta01"))
        {
            Debug.Log("Entroo...");
        }
    }

    
}
