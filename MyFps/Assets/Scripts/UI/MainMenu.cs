using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;
    public string loadToScene = "MainScene001";
    public GameObject menu;
    public GameObject credit;
    private bool isCreditShow = false;
    private void Start()
    {
        AudioManager.instance.Play("MenuMusic");
    }

    private void Update()
    {
        if (isCreditShow)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideCredits();
            }
            return;
        }
    }
    public void NewGame()
    {
        AudioManager.instance.Play("ButtonHit");
        //AudioManager.instance.StopBgm("MenuMusic");

        fader.FadeTo(loadToScene);
    }
    public void LoadGame()
    {
        Debug.Log("LoadGame");
    }
    public void Options()
    {
        AudioManager.instance.PlayBgm("SHAmb");

        Debug.Log("Options");
    }
    public void Credits()
    {
        isCreditShow = true;
        menu.SetActive(false);
        credit.SetActive(true);
    }

    private void HideCredits()
    {
        isCreditShow = false;
        menu.SetActive(true);
        credit.SetActive(false);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
