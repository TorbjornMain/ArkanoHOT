using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {
    public float health = 1;
    

    void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            BlockManager bm = FindObjectOfType<BlockManager>();
            if (bm != null)
                bm.blocks.Remove(this);
            Destroy(gameObject);
        }
    }
}
