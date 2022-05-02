using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class BOpening : MonoBehaviour
{
    public Text textBox;

    public GameObject thePlayer;

    void Start()
    {
        // 배경음 플레이
        AudioManager.instance.PlayBgm("SHAmb");

        // 플레어 컨트롤러 비활성화
        thePlayer.GetComponent<FirstPersonController>().enabled = false;

        StartCoroutine(SequencePlayer());
    }

    IEnumerator SequencePlayer()
    {
        yield return new WaitForSeconds(2f);

        //textBox.text = ""
        //line02.Play();
        //yield return new WaitForSeconds(3f);

        textBox.text = "";

        thePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
