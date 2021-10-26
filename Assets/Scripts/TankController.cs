using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    bool chasingPlayer = false;
    public Transform player;
    public float speed = 1;
    public float pushForce = 1;
    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si el tanque esta persiguiendo al jugador, que siempre vuelva a ver hacia el y se mueva hacia adelante
        if (chasingPlayer)
        {
            // Rota al enemigo para que vea hacia el jugador
            transform.LookAt(player.position);
            // Mueve hacia el frente al enemigo
            rig.velocity = transform.forward * speed + new Vector3(0, rig.velocity.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            chasingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            chasingPlayer = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Con los tags se puede saber con lo que estoy chocando
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody playerRig = collision.gameObject.transform.GetComponent<Rigidbody>();
            playerRig.velocity = transform.forward * pushForce + new Vector3(0, playerRig.velocity.y, 0);
        }
    }
}
