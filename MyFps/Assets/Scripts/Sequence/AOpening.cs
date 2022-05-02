using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class AOpening : MonoBehaviour
{
    public SceneFader fader;
    //�ó����� �ؽ�Ʈ
    public Text textBox;
    //1��Ī �÷��̾�
    public GameObject thePlayer;

    public AudioSource line01;
    public AudioSource line02;
    // Start is called before the first frame update
    void Start()
    {
        // ����� �÷���
        AudioManager.instance.PlayBgm("SHAmb");
        //�÷��� ��Ʈ�ѷ� ��Ȱ��ȭ
        thePlayer.GetComponent<FirstPersonController>().enabled = false;

        StartCoroutine(SequencePlayer());
    }

    IEnumerator SequencePlayer()
    {
        // 2�ʵ��� �����ϰ� 2���Ŀ� ���ε��� ȿ�� ����
        // fader.FadeStart(2f);
        yield return new WaitForSeconds(2f);

        // 2�� ���� �ó����� �ؽ�Ʈ�� ���̰� ���ش�.
        textBox.text = "...Where am I ?";
        AudioManager.instance.PlayBgm("Scene02_Line01");
        yield return new WaitForSeconds(3f);

        //2�� ���� �ó����� �ؽ�Ʈ ���̰� ���ش�
        textBox.text = "I need to get out of here";
        AudioManager.instance.PlayBgm("Scene02_Line02");
        yield return new WaitForSeconds(3f);

        textBox.text = "";

        //�÷��� ��Ʈ�ѷ� Ȱ��ȭ
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
