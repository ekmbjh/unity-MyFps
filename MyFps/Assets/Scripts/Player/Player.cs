using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int ammoCount = 0;

    private bool isDead = false;

    public GameObject damageFlash;

    public SceneFader fader;
    public string loadToScene = "GameOver"; //변경할 씬 이름

    public Transform firstPersonChracter;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.instance.health = PlayerStats.instance.startHealth;
    }
    public void TakeDamage(float damage)
    {
        if (isDead)
            return;

        PlayerStats.instance.health -= damage;
        Debug.Log("Player health: " + PlayerStats.instance.health);
        StartCoroutine(firstPersonChracter.GetComponent<CameraShake>().Shake(0.25f, 0.3f));
        StartCoroutine(DamageEffect());

        if (PlayerStats.instance.health <= 0f && !isDead)
        {
            Die();
        }
    }

    IEnumerator DamageEffect()
    {
        damageFlash.SetActive(true);

        int rand = Random.Range(1, 4);
        if (rand == 1)
        {
            AudioManager.instance.PlayBgm("Hurt01");
        }
        else if (rand == 2)
        {
            AudioManager.instance.PlayBgm("Hurt02");
        }
        else
        {
            AudioManager.instance.PlayBgm("Hurt03");
        }
        yield return new WaitForSeconds(1.0f);
        damageFlash.SetActive(false);
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Game Over");
        fader.FadeTo(loadToScene);
    }
}
