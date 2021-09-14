using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossLifeBar : MonoBehaviour
{
    [SerializeField]
    Image life;
    [SerializeField]
    GameObject playerLife, barreiras,BOSS;
    [SerializeField]
    float damageRate, nextDamage;
    [SerializeField]
    float dmgBall,dmgSword;
    void Start()
    {
        life.fillAmount = 1;
    }
    private void Update()
    {
      if(life.fillAmount <= 0)
        {
            print("BOSSDIE");
            barreiras.SetActive(false);
            Destroy(BOSS);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            life.fillAmount -= dmgSword/100;
        }
        if (other.gameObject.tag == "Bullet")
        {
            life.fillAmount -= dmgBall / 100;
        }

        if(other.gameObject.tag == "Player" && Time.time > nextDamage)
        {
            nextDamage = Time.time + damageRate;
            playerLife.GetComponent<PlayerLifeController>().playerLife-= 2;
        }
    }
}
