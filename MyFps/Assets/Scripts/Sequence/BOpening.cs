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
        // ����� �÷���
        AudioManager.instance.PlayBgm("SHAmb");

        // �÷��� ��Ʈ�ѷ� ��Ȱ��ȭ
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
