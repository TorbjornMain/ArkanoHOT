using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PaddleMovement : MonoBehaviour {
    public float moveSpeed = 4;
    public float distanceConstraint = 3.5f;
    public float accelerationFactor = 0.6f;
    public float timeFadeFactor = 0.3f;
    public float minTimeScale = 0.1f;
    public Vector3 ballSpawnOffset = Vector3.forward;
    public BallMovement ballPrefab;
    Rigidbody rb;
    BallManager bm;
    float horizIn = 0;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        bm = FindObjectOfType<BallManager>();
	}
	
	// Update is called once per frame
	void Update () {
        horizIn = Mathf.Lerp(horizIn, Input.GetAxisRaw("Horizontal"), Time.unscaledDeltaTime * accelerationFactor);
        Time.timeScale = Mathf.Lerp(Time.timeScale, Mathf.Max(Mathf.Abs(horizIn), minTimeScale), Time.unscaledDeltaTime * timeFadeFactor);
        rb.velocity = Vector3.right * moveSpeed * horizIn;

        if (bm != null)
        {
            if(bm.activeBalls.Count == 0)
            {
                if(Input.GetButtonDown("Fire1"))
                {
                    BallMovement ballInstance = bm.SpawnBall(ballPrefab);
                    ballInstance.transform.position = transform.position + ballSpawnOffset;
                    ballInstance.transform.forward = (transform.forward + (Vector3.right * rb.velocity.x * ballInstance.velocityKeep)).normalized;
                }
            }
        }
	}
}
