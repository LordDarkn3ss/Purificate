using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    
    [SerializeField]
   Transform player;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        if (transform.position.x > player.position.x)
        {
            rb.AddForce(Vector2.right * PlayerController.bulletSpeed * Time.deltaTime);
        }
        else
        {
            rb.AddForce(Vector2.right * PlayerController.bulletSpeed * Time.deltaTime * -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
