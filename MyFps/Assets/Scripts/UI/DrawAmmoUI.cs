using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawAmmoUI : MonoBehaviour
{
    public Text ammoCount;

    // Update is called once per frame
    void Update()
    {
        ammoCount.text = PlayerStats.instance.ammoCount.ToString();
    }
}
