using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] item;
    public GameObject fallingBlock;
    public float reduceTime;
    public float blockSpawnTimeMax;
    public float blockSpawnTimeMin;
    public float itemSpawnTimeMax;
    public float itemSpawnTimeMin;

    float xScreenHalfSize;
    float yScreenHalfSize;

    float timeAfterReduce;
    float timeAfterSpawn;
    float blockSpawnTime;
    float nextBlockSpawnTime = 0;

    float itemSpawnTime;
    float nextItemSpawnTime;

    Vector3 spawnPoint;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        yScreenHalfSize = 2 * Camera.main.orthographicSize / 2;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect / 2;
        nextBlockSpawnTime = 0;
        nextItemSpawnTime = 1;

        Balance();
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        BlockSpawn();
        ItemSpawn();
    }

    void BlockSpawn()
    {
        if (timeAfterSpawn >= nextBlockSpawnTime)
        {
            RandomPosition();

            blockSpawnTime = Random.Range(blockSpawnTimeMin, blockSpawnTimeMax);
            nextBlockSpawnTime = blockSpawnTime + timeAfterSpawn;

            Instantiate(fallingBlock, spawnPoint, fallingBlock.transform.rotation);
        }
    }

    void ItemSpawn()
    {
        if (timeAfterSpawn >= nextItemSpawnTime)
        {
            RandomPosition();

            itemSpawnTime = Random.Range(itemSpawnTimeMin, itemSpawnTimeMax);
            nextItemSpawnTime = itemSpawnTime + timeAfterSpawn;

            int randomItem = Random.Range(0, item.Length);
            Instantiate(item[randomItem], spawnPoint, item[randomItem].transform.rotation);
        }
    }

    void RandomPosition()
    {
        int randomSpawn = Random.Range(0, 4);

        switch (randomSpawn)
        {
            case 0:
                SpawnFixPositiveX();
                break;
            case 1:
                SpawnFixNegativeX();
                break;
            case 2:
                SpawnFixPositiveY();
                break;
            case 3:
                SpawnFixNegativeY();
                break;
        }

    }

    void SpawnFixPositiveX()
    {
        spawnPoint.x = xScreenHalfSize * 2;
        spawnPoint.y = Random.Range(-yScreenHalfSize, yScreenHalfSize);
    }

    void SpawnFixNegativeX()
    {
        spawnPoint.x = -(xScreenHalfSize * 2);
        spawnPoint.y = Random.Range(-yScreenHalfSize, yScreenHalfSize);
    }

    void SpawnFixPositiveY()
    {
        spawnPoint.x = Random.Range(-xScreenHalfSize, xScreenHalfSize);
        spawnPoint.y = yScreenHalfSize;
    }

    void SpawnFixNegativeY()
    {
        spawnPoint.x = Random.Range(-xScreenHalfSize, xScreenHalfSize);
        spawnPoint.y = -(yScreenHalfSize);
    }

    void Balance()
    {
        if (blockSpawnTimeMin >= 0.2f)
        {
            blockSpawnTimeMax -= reduceTime;
            blockSpawnTimeMin -= reduceTime;
            //Debug.Log(blockSpawnTimeMin);
            Invoke("Balance", 2f);
        }
    }

}
