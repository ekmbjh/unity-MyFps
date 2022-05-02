using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class Pause : MonoBehaviour
{
    public SceneFader fader;
    public string loadToScene = "MainMenu";
    public GameObject pauseUI;
    public GameObject thePlayer;

    public bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            thePlayer.GetComponent<FirstPersonController>().enabled = true;
        }
    }

    public void Continue()
    {
        Toggle();
        //pauseUI.SetActive(false);
        //isPause = false;
        //Time.timeScale = 1f;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        fader.FadeTo(loadToScene);
    }
}
