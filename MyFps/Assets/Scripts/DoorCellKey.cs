using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellKey : Interaction
{
    public GameObject theDoor;

    public Text textBox;
    public override void DoAction()
    {
        if (PlayerStats.instance.haveKeys[(int)KeyWord.ROOM01_DOORKEY])
            StartCoroutine(OpenDoor());
        else
            StartCoroutine(LockedDoor());
    }

    IEnumerator OpenDoor()
    {
        theDoor.GetComponent<Animation>().Play("Door1OpenAnim");
        AudioManager.instance.Play("CreakyDoor2");
        yield return new WaitForSeconds(1f);
    }
    IEnumerator LockedDoor()
    {
        unInteractive = true;
        this.GetComponent<BoxCollider>().enabled = true;
        textBox.text = "";
        AudioManager.instance.Play("DoorLocked");
        yield return new WaitForSeconds(1f);

        textBox.text = "I need The Key";
        yield return new WaitForSeconds(2f);
        
        textBox.text = "";
        unInteractive = false;
    }
}
