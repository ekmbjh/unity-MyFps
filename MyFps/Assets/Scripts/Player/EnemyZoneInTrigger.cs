using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZoneInTrigger : MonoBehaviour
{
    public Transform theMutant;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            theMutant.GetComponent<Mutant>().ChangeState(Mutantstate.M_WALK);

        }
    }
}
