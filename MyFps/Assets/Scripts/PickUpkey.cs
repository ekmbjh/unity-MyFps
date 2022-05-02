using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpkey : Interaction
{
    public GameObject theKey;
    public override void DoAction()
    {
        PlayerStats.instance.haveKeys[(int)KeyWord.ROOM01_DOORKEY] = true;

        theKey.SetActive(false);
    }
}
