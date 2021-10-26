using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rigidBody;
    public float speed = 1;
    public float rotationSpeed = 1;
    public float jumpForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Se obtiene el rigidbody para mover el jugador
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Saltar
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Aplicalo la fuerza de salto a la velocidad en y del rigidbody
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y + jumpForce, rigidBody.velocity.z);
        }

        // Moverse hacia adelante y atras
        // Obtengo la direccion a la que el jugador quiere moverse. -1 si quiero ir hacia atras o 1 si quiero ir hacia adelante
        float vertical = Input.GetAxis("Vertical");

        // Le doy la velocidad correspondiente al rigidbody para moverse en esta direccion
        rigidBody.velocity = transform.forward * speed * vertical + new Vector3(0, rigidBody.velocity.y, 0);

        // Girar hacia la derecha e izquierda
        // Obtengo la direccion a la que el jugador quiere moverse. -1 si quiero ir hacia la izquierda o 1 si quiero ir hacia derecha
        float horizontal = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3( 0, rotationSpeed * horizontal * Time.deltaTime, 0));

    }
}
