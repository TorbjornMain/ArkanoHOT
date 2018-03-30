using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PaddleMovement : MonoBehaviour {
    public float moveSpeed = 4;
    public float distanceConstraint = 3.5f;
    public float timeFadeFactor = 0.3f;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizIn = Input.GetAxisRaw("Horizontal");
        Time.timeScale = Mathf.Lerp(Time.timeScale, Mathf.Abs(horizIn), Time.unscaledDeltaTime * timeFadeFactor);
        Vector3 posOffset = new Vector3(Mathf.Clamp(transform.position.x + Time.deltaTime * moveSpeed * horizIn, -distanceConstraint, distanceConstraint), transform.position.y, transform.position.z);
        rb.velocity = posOffset - transform.position;
        rb.MovePosition(posOffset);
        print(rb.velocity);        
	}
}
