using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour {
    public float speed = 5;
    public float velocityKeep = 0.1f;
    public float damage = 1;
    Rigidbody rb;



	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.forward * speed;
	}

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                transform.forward = (Vector3.Reflect(transform.forward, collision.contacts[0].normal) + ((collision.rigidbody != null) ? Vector3.right * velocityKeep * collision.rigidbody.velocity.x : Vector3.zero)).normalized;
                break;
            default:

                break;
        }
        collision.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
    }
}
