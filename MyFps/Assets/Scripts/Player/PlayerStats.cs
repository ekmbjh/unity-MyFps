using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [HideInInspector]
    public float health;
    public float startHealth = 20f;

    public WeaponType weaponType = WeaponType.NONE;

    // 탄환 관리 변수
    public int ammoCount;

    public bool[] haveKeys;
    // Start is called before the first frame update
    void Start()
    {
        // 값 초기화
        //weaponType = WeaponType.NONE;
        ammoCount = 0;

        haveKeys = new bool[(int)KeyWord.MAX_K];
    }

    public void AddAmmo(int amount)
    {
        ammoCount += amount;
    }

    public bool UseAmmo(int amount)
    {
        if (ammoCount < amount)
        {
            return false;
        }
        ammoCount -= amount;
        return true;
    }
}

public enum WeaponType
{
    NONE,
    PISTOL,

}

public enum KeyWord
{
    ROOM01_DOORKEY,
    ROOM02_LEFTEYE,
    ROOM04_RIGHTEYE,
    MAX_K
}
