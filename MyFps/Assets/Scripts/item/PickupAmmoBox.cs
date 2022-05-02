using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAmmoBox : MonoBehaviour
{
    public int giveAmmo = 7;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerStats.instance.AddAmmo(giveAmmo);

            Destroy(gameObject);
        }
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
