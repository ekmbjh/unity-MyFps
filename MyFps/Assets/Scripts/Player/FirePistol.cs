using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject theGun;
    //�ѱ� �߻� ȭ��
    public GameObject fireFlash;
    
    //���� ����
    private bool isFire = false;
    //���ݷ�
    public float attackDamage = 5f;


    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.instance.weaponType != WeaponType.PISTOL)
        {
            return;
        }
        //Fire1 : ���� ��Ʈ��Ű �Ǵ� ���콺 ���� Ŭ���� �̺�Ʈ �߻�
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
            //�浹ü�� ������ ����
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
