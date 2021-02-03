using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ground;
    public ObjectManager objectManager;
    public GameObject difficultyUp;

    public float reduceTime;
    public float blockSpawnTimeMin;
    public float blockSpawnTimeMax;
    public float itemSpawnTimeMin;
    public float itemSpawnTimeMax;

    float xScreenHalfSize;
    float yScreenHalfSize;

    float timeAfterReduce;
    float timeAfterSpawn;

    float blockSpawnTime;
    float nextBlockSpawnTime;

    float itemSpawnTime;
    float nextItemSpawnTime;

    int randomSpawn;

    int enemyCount;
    int itemCount;

    string[] enemyName;
    string[] itemName;

    Vector3 target;
    Vector3 spawnPoint;

    void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        itemCount = 0;
        enemyCount = 0;

        nextBlockSpawnTime = 1;
        nextItemSpawnTime = 1;

        enemyName = new string[] { "Enemy01", "Enemy02", "Enemy03", "Enemy04", "Enemy05" };
        itemName = new string[] { "GoldCoin", "SilverCoin", "BronzeCoin", "HealthPill", "InvincibilityPill"};

        Invoke("DifficultyUI", 10f);
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
            int moveSpeed = Random.Range(1, 3);
            float randomScale = Random.Range(0.05f, 0.25f);
            enemyCount++;
            RandomPosition();

            int enemySequence = enemyCount % enemyName.Length;
            GameObject block = objectManager.MakeObject(enemyName[enemySequence]);
            Rigidbody2D blockRigid = block.GetComponent<Rigidbody2D>();

            block.transform.position = spawnPoint;
            target = ground.transform.position - spawnPoint;
            blockRigid.velocity = target.normalized * moveSpeed;
            block.transform.localScale = new Vector3(randomScale, randomScale, transform.localScale.z);

            blockSpawnTime = Random.Range(blockSpawnTimeMin, blockSpawnTimeMax);
            nextBlockSpawnTime = blockSpawnTime + timeAfterSpawn;
        }
    }

    void ItemSpawn()
    {
        if (timeAfterSpawn >= nextItemSpawnTime)
        {
            int moveSpeed = Random.Range(1, 3);
            itemCount++;
            RandomPosition();

            int itemSequence = itemCount % itemName.Length;
            GameObject item = objectManager.MakeObject(itemName[itemSequence]);
            Rigidbody2D itemRigid = item.GetComponent<Rigidbody2D>();

            item.transform.position = spawnPoint;
            target = ground.transform.position - spawnPoint;
            itemRigid.velocity = target.normalized * moveSpeed;

            itemSpawnTime = Random.Range(itemSpawnTimeMin, itemSpawnTimeMax);
            nextItemSpawnTime = itemSpawnTime + timeAfterSpawn;
        }
    }

    void RandomPosition()
    {
        randomSpawn = Random.Range(0, 4);
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
        spawnPoint.x = xScreenHalfSize;
        spawnPoint.y = Random.Range(-yScreenHalfSize, yScreenHalfSize);
    }

    void SpawnFixNegativeX()
    {
        spawnPoint.x = -(xScreenHalfSize);
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

    public bool Balance()
    {
        if (blockSpawnTimeMin >= 0f)
        {
            blockSpawnTimeMax -= reduceTime;
            blockSpawnTimeMin -= reduceTime;
            return true;
        }
        return false;
    }

    void DifficultyUI()
    {
        bool isOk = Balance();
        if (isOk)
        {
            difficultyUp.SetActive(true);
            Invoke("OffDifficultyUI", 1.5f);
        }
        
    }

    void OffDifficultyUI()
    {
        difficultyUp.SetActive(false);
        Invoke("DifficultyUI", 10f);
    }
}
