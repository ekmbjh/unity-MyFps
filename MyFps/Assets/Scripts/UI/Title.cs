using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public SceneFader fader;
    public string loadToScene = "MainMenu";
    public float timer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            GoToMenu();
            return;
        }

        timer -= Time.deltaTime;
        if (Input.anyKeyDown && timer < 3f)
        {
            GoToMenu();
        }
    }

    void GoToMenu()
    {
        fader.FadeTo(loadToScene);
    }
}
