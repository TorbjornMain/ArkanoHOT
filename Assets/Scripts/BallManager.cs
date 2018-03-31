using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public List<BallMovement> activeBalls;
    public int numLives = 3;
    bool ballsOnScreen = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(activeBalls.Count == 0)
        {
            if (ballsOnScreen == true)
            {
                numLives--;
                if(numLives <= 0)
                {
                    //Do game over logic
                }
            }

            ballsOnScreen = false;
        }
        else
        {
            ballsOnScreen = true;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        BallMovement ball = other.GetComponent<BallMovement>();
        if(ball != null)
        {
            if(activeBalls.Contains(ball))
            {
                activeBalls.Remove(ball);
            }
            Destroy(ball.gameObject);
        }
    }

    public BallMovement SpawnBall(BallMovement ballTemplate)
    {
        BallMovement bm = Instantiate(ballTemplate);
        activeBalls.Add(bm);
        return bm;
    }
}
