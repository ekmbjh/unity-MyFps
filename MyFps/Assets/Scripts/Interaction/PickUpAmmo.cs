using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpAmmo : Interaction
{
    public GameObject ammoBox;

    public int giveAmmo = 7;

    public override void DoAction()
    {
        //ammoBox.SetActive(false);
        PlayerStats.instance.AddAmmo(giveAmmo);

        Destroy(gameObject);
    }
}
