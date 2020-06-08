using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int health;
    public Player player;

    public Image[] UIhealth;
    public Text UIPoint;
    public GameObject restartBtn;

    void Update()
    {
        UIPoint.text = "score: " + totalPoint;
    }

    public void HealthDown()
    {
        if (health > 1 && health <= 3)
        {
            health--;
            UIhealth[health].color = new Color(1, 0, 0, 0);
            DrawPlayerHealth(health);
            Debug.Log(health);
        }
        else
        {
            Debug.Log("Player Die!");
            Time.timeScale = 0;
            restartBtn.SetActive(true);
            
        }
    }

    public void DrawPlayerHealth(int Health)
    {
        if(Health <= 3)
        {
            for (int i = 0; i < Health; i++)
            {
                UIhealth[i].color = new Color(1, 1, 1, 1);
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
