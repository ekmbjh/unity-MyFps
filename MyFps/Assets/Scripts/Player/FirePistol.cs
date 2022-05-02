using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject theGun;
    //총구 발사 화염
    public GameObject fireFlash;
    
    //연사 방지
    private bool isFire = false;
    //공격력
    public float attackDamage = 5f;


    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.instance.weaponType != WeaponType.PISTOL)
        {
            return;
        }
        //Fire1 : 좌측 컨트롤키 또는 마우스 왼쪽 클리시 이벤트 발생
        if(Input.GetButtonDown("Fire1"))
        {
            if (!isFire)
            {   
                if (PlayerStats.instance.UseAmmo(1))
                {
                    StartCoroutine(Fire());
                }
                else
                {
                    Debug.Log("You need to reload");
                }
            }
        }
    }

    IEnumerator Fire()
    {
        isFire = true;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            //충돌체가 있으면 실행
            if (hit.transform.tag == "zombie")
            {
                Debug.Log("Damage 5");
                hit.transform.GetComponent<Zombie>().TakeDamage(attackDamage);
            }
            else if(hit.transform.tag == "BreakObject")
            {
                Debug.Log("Hit Damage 5");
                hit.transform.GetComponent<BreakObject>().TakeDamage(attackDamage);
            }
        }

        theGun.GetComponent<Animation>().Play("PistolFireAnim");
        fireFlash.SetActive(true);
        fireFlash.GetComponent<Animation>().Play("FireFlashAnim");
        AudioManager.instance.Play("PistolShot");

        yield return new WaitForSeconds(0.3f);
        fireFlash.SetActive(false);

        isFire = false;
    }
}
