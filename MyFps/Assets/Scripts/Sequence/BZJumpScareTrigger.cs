using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZJumpScareTrigger : MonoBehaviour
{
    public GameObject theDoor;

    public AudioSource bgm01;
    public AudioSource doorBang;
    public AudioSource jumpScare;

    public GameObject theZombie;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(SequencePlayer());  
    }

    IEnumerator SequencePlayer()
    {
        //Ʈ���� ��Ȱ��ȭ
        this.GetComponent<BoxCollider>().enabled = false;

        // ������� ����
        AudioManager.instance.PlayBgm("SHAmb");

        //������ �ִϸ��̼�
        theDoor.GetComponent<Animation>().Play("Door1OpenAnim");
        //�� ������ �Ҹ�
        AudioManager.instance.PlayBgm("DoorBang");
        theZombie.SetActive(true);

        yield return new WaitForSeconds(1f);
        //���� ���� ����
        AudioManager.instance.PlayBgm("JumpscareTune");
        theZombie.GetComponent<Zombie>().ChangeState(zState.Z_WALK);
    }
}
