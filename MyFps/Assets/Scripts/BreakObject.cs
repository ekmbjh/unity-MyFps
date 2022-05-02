using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    public float health = 1f;

    private bool isBreak = false;

    public GameObject fakeObject;
    public GameObject breakObject;
    public GameObject sphereObject;
    public GameObject theKey;

    public bool haveItem = false;

    public bool isUnbreakable = false;
    public void TakeDamage(float damage)
    {
        if (isUnbreakable)
            return;

        health -= damage;

        if (health <= 0f && !isBreak)
        {
            StartCoroutine(Break());
        }
    }
 
    IEnumerator Break()
    {
        isBreak = true;

        fakeObject.SetActive(false);
        sphereObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        
        breakObject.SetActive(true);
        AudioManager.instance.Play("PotterySmash");
        yield return new WaitForSeconds(0.1f);

        sphereObject.SetActive(false);
        this.GetComponent<Collider>().enabled = false;

        // 숨겨진 아이템 보여주기
        if (haveItem)
        {
            theKey.SetActive(true);
        }

    }
}
