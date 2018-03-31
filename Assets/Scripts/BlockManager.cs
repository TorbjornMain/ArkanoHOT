﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    public int level = 0;
    public List<BlockScript> blocks;
    public float levelHealthScalar = 1;
    public BlockScript blockPrefab;
    public LevelData[] levelDatas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(blocks.Count == 0)
        {
            level++;
            BallManager bm = FindObjectOfType<BallManager>();
            bm.SendMessage("ProgressLevel");
            SpawnLevel();
        }
	}

    void SpawnLevel()
    {
        int ind = Random.Range(0, levelDatas.Length);
        for (int i = 0; i < levelDatas[ind].spawnPoints.Count; i++)
        {
            SpawnBlock(levelDatas[ind].spawnPoints[i], blockPrefab.health + (levelHealthScalar * (level-1)));
        }
    }

    void SpawnBlock(Vector3 pos, float health)
    {
        BlockScript b = Instantiate(blockPrefab);
        b.transform.position = pos;
        b.health = health;
        blocks.Add(b);
    }
}
