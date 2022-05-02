using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;
    public string loadToScene = "MainScene001";

    private void Start()
    {
        AudioManager.instance.Play("MenuMusic");
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
        Debug.Log("Credits");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
