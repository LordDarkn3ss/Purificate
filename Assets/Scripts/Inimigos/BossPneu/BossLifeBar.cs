using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossLifeBar : MonoBehaviour
{
    [SerializeField]
    Image life;
    [SerializeField]
    float dmgBall,dmgSword;
    void Start()
    {
        life.fillAmount = 1;
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
    }
}
