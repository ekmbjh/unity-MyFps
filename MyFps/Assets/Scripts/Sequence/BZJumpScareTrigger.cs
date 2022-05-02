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
        //트리거 비활성화
        this.GetComponent<BoxCollider>().enabled = false;

        // 배경음을 실행
        AudioManager.instance.PlayBgm("SHAmb");

        //문여는 애니메이션
        theDoor.GetComponent<Animation>().Play("Door1OpenAnim");
        //문 열리는 소리
        AudioManager.instance.PlayBgm("DoorBang");
        theZombie.SetActive(true);

        yield return new WaitForSeconds(1f);
        //좀비 등장 사운드
        AudioManager.instance.PlayBgm("JumpscareTune");
        theZombie.GetComponent<Zombie>().ChangeState(zState.Z_WALK);
    }
}
