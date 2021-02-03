using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int health;

    public Image[] healthUI;
    public Text pointUI;

    public Text currentPointText;
    public Text highestPointText;

    public Player player;
    public Spawner spawner;
    public GameObject restartBtn;

    static int highestPoint;

    void Start()
    {
        Time.timeScale = 1;
        highestPoint = PlayerPrefs.GetInt("HighestPoint");
    }

    void Update()
    {
        pointUI.text = "score: " + totalPoint;
    }

    void NewRecord()
    {
        if (totalPoint >= highestPoint)
        {
            highestPoint = totalPoint;
        }
        PlayerPrefs.SetInt("HighestPoint", highestPoint);
        currentPointText.text = totalPoint.ToString();
        highestPointText.text = highestPoint.ToString();
    }

    public void HealthDown()
    {
        if (health > 1 && health <= 3)
        {
            health--;
            healthUI[health].color = new Color(1, 0, 0, 0);
            DrawPlayerHealth(health);
        }
        else
        {
            health--;
            healthUI[health].color = new Color(1, 0, 0, 0);

            NewRecord();
            Time.timeScale = 0;
            restartBtn.SetActive(true);
        }
    }

    public void DrawPlayerHealth(int Health)
    {
        if (Health <= 3)
        {
            for (int i = 0; i < Health; i++)
            {
                healthUI[i].color = new Color(1, 1, 1, 1);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
