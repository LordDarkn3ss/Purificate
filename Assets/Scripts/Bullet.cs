using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed, tempoDestroir;
    void Start()
    {
       Destroy(gameObject,tempoDestroir);
    }

    
    void Update()
    {
      transform.Translate(Vector2.right * speed * Time.deltaTime);  
    }
}
