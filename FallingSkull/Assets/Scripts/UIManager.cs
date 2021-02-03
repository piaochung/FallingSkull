using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject titlePos;
    public GameObject gameName;
    public GameObject buttonSet;
    public GameObject InformationBtn;
    public GameObject DeveloperBtn;

    void Update()
    {
        gameName.transform.position = Vector2.MoveTowards(gameName.transform.position, titlePos.transform.position, 0.2f);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ActiveInformation()
    {
        buttonSet.SetActive(false);
        InformationBtn.SetActive(true);
    }

    public void ActiveButton()
    {
        buttonSet.SetActive(false);
        DeveloperBtn.SetActive(true);
    }

    public void ExitButton(GameObject panel)
    {
        panel.SetActive(false);
        buttonSet.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
