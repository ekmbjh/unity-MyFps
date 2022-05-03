using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicktUpRightEye : Interaction
{
    public GameObject rightEyePiece;
    public GameObject rightEyeUI;
    public GameObject rightEyeLight;

    public GameObject fakeWall;
    public GameObject hiddenWall;

    public GameObject fullEyeLight;

    public override void DoAction()
    {
        StartCoroutine(ShowLeftEyeUI());
    }

    IEnumerator ShowLeftEyeUI()
    {
        PlayerStats.instance.haveKeys[(int)KeyWord.ROOM04_RIGHTEYE] = true;
        rightEyePiece.SetActive(false);
        rightEyeLight.SetActive(false);

        yield return new WaitForSeconds(0.3f);
        rightEyeUI.SetActive(true);

        yield return new WaitForSeconds(2f);
        rightEyeUI.SetActive(false);

        // 숨겨진 출구가 보이도록 한다.
        fakeWall.SetActive(false);
        hiddenWall.SetActive(true);

        // 퍼즐 박스 조명 온
        fullEyeLight.SetActive(true);
    }
}
