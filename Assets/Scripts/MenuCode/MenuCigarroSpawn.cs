using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCigarroSpawn : MonoBehaviour
{
    [SerializeField]
    float timer;
    [SerializeField]
    Image cigarros;
    [SerializeField]
    GameObject lE, lD;
    float lEFloat, lDFloat,Spawn;

    [SerializeField]
    Canvas menu;
    void Start()
    {
        lEFloat = lE.transform.position.x;
        lDFloat = lD.transform.position.x;
        Spawn = transform.position.y;

        StartCoroutine(spawnTimer(timer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTimer(float timer)
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            Instantiate(cigarros, new Vector2(Random.Range(lEFloat, lDFloat), Spawn), Quaternion.identity,menu.transform);
        }
    }
}
