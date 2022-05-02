using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol : Interaction
{
    public GameObject fakePistol;
    public GameObject realPistol;
    public GameObject theArrow;

    public GameObject jumpScareTrigger;

    public GameObject AmmoUI;

    public GameObject ammoLight;

    public override void DoAction()
    {
        //interacive action
        fakePistol.SetActive(false);
        realPistol.SetActive(true);
        theArrow.SetActive(false);
        AmmoUI.SetActive(true);
        ammoLight.SetActive(true);

        PlayerStats.instance.weaponType = WeaponType.PISTOL;

        jumpScareTrigger.SetActive(true);
    }
}
