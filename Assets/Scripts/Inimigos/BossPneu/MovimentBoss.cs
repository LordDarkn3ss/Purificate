using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentBoss : MonoBehaviour
{
    [SerializeField]
    string tag;


    [SerializeField]
    LayerMask plataform;
    [SerializeField]
    float speed, RangeAttack,fireBallSpawnRange;
    [HideInInspector]
    GameObject player;
    [SerializeField]
    GameObject fireBall;
    [SerializeField]
    GameObject[] spawns;
    

    bool atacando = false;

    [SerializeField]
    Animator anim;
   
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Acha o objeto com tag player
    }

    void Update()
    {
        

        if (!atacando)
        {
            AttackFire(); //Attack quando o jogador está inalcançavel 
            AttackJump(); //Attack ao se aproximar do jogador
            Moviment(); //movimentação horizontal basica
            Girar(); //Girar na direção do jogador
        }
    }

    private void OnCollisionStay(Collision other)
    {
        
            if (other.gameObject.tag == tag) //Para ignorar a fisica com as plataformas
            {
                Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            }
        if (other.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }


    }
    void Moviment()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y,transform.position.z), speed * Time.deltaTime);
    }

    void AttackFire()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < RangeAttack && transform.position.y + 2 < player.transform.position.y)
        {
           
            atacando = true;
            anim.SetTrigger("B");

        }
    }
    void AttackJump()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < RangeAttack && transform.position.y + 2 > player.transform.position.y)
        {
           
            atacando = true;
            anim.SetTrigger("A");
           
        }

        


    }

    void Girar()
    {
        {
            if (player.transform.position.x > transform.position.x) { transform.eulerAngles = new Vector2(0, 180); }
            else{ transform.eulerAngles = new Vector2(0, 0); }
        }
    }

    public void SetFalse() //Resetar a limitação de movimento
    {
     
        
        atacando = false;
    }

    public void SpawnFireBalls()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(fireBall, spawns[i].transform.position, Quaternion.identity);
        }
        
    }
}
