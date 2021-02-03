using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemy01Prefab;
    public GameObject enemy02Prefab;
    public GameObject enemy03Prefab;
    public GameObject enemy04Prefab;
    public GameObject enemy05Prefab;

    public GameObject goldCoinPrefab;
    public GameObject silverCoinPrefab;
    public GameObject bronzeCoinPrefab;

    public GameObject healthPillPrefab;
    public GameObject invincibilityPillPrefab;

    GameObject[] enemy01;
    GameObject[] enemy02;
    GameObject[] enemy03;
    GameObject[] enemy04;
    GameObject[] enemy05;

    GameObject[] goldCoin;
    GameObject[] silverCoin;
    GameObject[] bronzeCoin;

    GameObject[] healthPill;
    GameObject[] invincibilityPill;

    GameObject[] targetPoll;

    void Start()
    {
        enemy01 = new GameObject[7];
        enemy02 = new GameObject[7];
        enemy03 = new GameObject[7];
        enemy04 = new GameObject[7];
        enemy05 = new GameObject[7];

        goldCoin = new GameObject[3];
        silverCoin = new GameObject[3];
        bronzeCoin = new GameObject[3];

        healthPill = new GameObject[3];
        invincibilityPill = new GameObject[3];

        Generate();
    }

    void Generate()
    {
        for (int i = 0; i < enemy01.Length; i++)
        {
            enemy01[i] = Instantiate(enemy01Prefab);
            enemy01[i].SetActive(false);
        }

        for (int i = 0; i < enemy02.Length; i++)
        {
            enemy02[i] = Instantiate(enemy02Prefab);
            enemy02[i].SetActive(false);
        }

        for (int i = 0; i < enemy03.Length; i++)
        {
            enemy03[i] = Instantiate(enemy03Prefab);
            enemy03[i].SetActive(false);
        }

        for (int i = 0; i < enemy04.Length; i++)
        {
            enemy04[i] = Instantiate(enemy04Prefab);
            enemy04[i].SetActive(false);
        }

        for (int i = 0; i < enemy05.Length; i++)
        {
            enemy05[i] = Instantiate(enemy05Prefab);
            enemy05[i].SetActive(false);
        }

        for (int i = 0; i < goldCoin.Length; i++)
        {
            goldCoin[i] = Instantiate(goldCoinPrefab);
            goldCoin[i].SetActive(false);
        }

        for (int i = 0; i < silverCoin.Length; i++)
        {
            silverCoin[i] = Instantiate(silverCoinPrefab);
            silverCoin[i].SetActive(false);
        }

        for (int i = 0; i < bronzeCoin.Length; i++)
        {
            bronzeCoin[i] = Instantiate(bronzeCoinPrefab);
            bronzeCoin[i].SetActive(false);
        }

        for (int i = 0; i < healthPill.Length; i++)
        {
            healthPill[i] = Instantiate(healthPillPrefab);
            healthPill[i].SetActive(false);
        }

        for (int i = 0; i < invincibilityPill.Length; i++)
        {
            invincibilityPill[i] = Instantiate(invincibilityPillPrefab);
            invincibilityPill[i].SetActive(false);
        }
    }

    public GameObject MakeObject(string type)
    {
        switch (type)
        {
            case "Enemy01":
                targetPoll = enemy01;
                break;
            case "Enemy02":
                targetPoll = enemy02;
                break;
            case "Enemy03":
                targetPoll = enemy03;
                break;
            case "Enemy04":
                targetPoll = enemy04;
                break;
            case "Enemy05":
                targetPoll = enemy05;
                break;
            case "GoldCoin":
                targetPoll = goldCoin;
                break;
            case "SilverCoin":
                targetPoll = silverCoin;
                break;
            case "BronzeCoin":
                targetPoll = bronzeCoin;
                break;
            case "HealthPill":
                targetPoll = healthPill;
                break;
            case "InvincibilityPill":
                targetPoll = invincibilityPill;
                break;
        }

        for (int i = 0; i < targetPoll.Length; i++)
        {
            if (!targetPoll[i].activeSelf)
            {
                targetPoll[i].SetActive(true);
                return targetPoll[i];
            }
        }
        return null;
    }
}
