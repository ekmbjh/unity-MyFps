using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLeftEye : Interaction
{
    public GameObject leftEyePiece;
    public GameObject leftEyeUI;
    public GameObject leftEyeLight;

    public override void DoAction()
    {
        StartCoroutine(ShowLeftEyeUI());
    }

    IEnumerator ShowLeftEyeUI()
    {
        PlayerStats.instance.haveKeys[(int)KeyWord.ROOM02_LEFTEYE] = true;
        leftEyePiece.SetActive(false);
        leftEyeLight.SetActive(false);
        
        yield return new WaitForSeconds(0.3f);
        leftEyeUI.SetActive(true);

        yield return new WaitForSeconds(2f);
        leftEyeUI.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
