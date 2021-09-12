using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    [SerializeField]
    GameObject lifeBar;
    [SerializeField]
    Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("ativar", true);
            lifeBar.GetComponent<PlayerLifeController>().playerLife = 20;
            lifeBar.GetComponent<PlayerLifeController>().playerLifeMax = 20;
        }

    }
}
