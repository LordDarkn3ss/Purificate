using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimization : MonoBehaviour
{
    [SerializeField]
    GameObject[] noStatics;
    [SerializeField]
    GameObject player;
    [SerializeField]
    float rangerRender;
    float pDistance;


    void Update()
    {
        for (int i = 0; i < noStatics.Length; i++)
        {
            pDistance = Vector3.Distance(player.transform.position, noStatics[i].transform.position);
            if(pDistance>=rangerRender)
            {
                noStatics[i].SetActive(false);
            }
            else
            {
                noStatics[i].SetActive(true);
            }
        } 
    }
}
