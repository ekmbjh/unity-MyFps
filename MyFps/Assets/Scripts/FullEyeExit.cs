using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullEyeExit : Interaction
{
    public Text textBox;
    public GameObject fullEye;
    public GameObject emptyEye;

    public GameObject hiddenExit;
    public GameObject hiddenExitTrigger;
    public override void DoAction()
    {
        if (PlayerStats.instance.haveKeys[(int)KeyWord.ROOM02_LEFTEYE]
            && PlayerStats.instance.haveKeys[(int)KeyWord.ROOM04_RIGHTEYE])
        {
            StartCoroutine(OpenHiddenExit());
        }
        else
        {
            StartCoroutine(LockedHiddenExit());
        }
    }

    IEnumerator OpenHiddenExit()
    {
        emptyEye.SetActive(false);
        fullEye.SetActive(true);
        hiddenExit.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1f);

        hiddenExitTrigger.SetActive(true);
    }

    IEnumerator LockedHiddenExit()
    {
        // Interaction 기능 제한
        unInteractive = true;

        // 충돌체 활성화
        this.GetComponent<BoxCollider>().enabled = true;
        
        // 퍼즐 조각이 필요해
        textBox.text = "More Pictures";
        yield return new WaitForSeconds(2f);

        textBox.text = "";
        unInteractive = false;
    }
}
