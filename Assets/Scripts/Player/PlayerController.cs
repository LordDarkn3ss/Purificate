using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator player;

    [SerializeField] //ataques
    float waterA1Cust;
    [SerializeField]
    GameObject espada, playerSprite;
    [SerializeField]
    public GameObject lifeBar;



    [SerializeField] //Regen
    float mPRegen;

    //Bala
    [SerializeField]
    Transform bulletSpawn;
    [SerializeField]
    GameObject bulletOBJ;
    [SerializeField]
    float fireRate, nextFire, damageRate, nextDamage;

    //movimenta��o
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [SerializeField]
    float playerSpeed = 2.0f;
    [SerializeField]
    float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

  


    Rigidbody rb;
    
    void Start()
    {
        //Timers
        //StartCoroutine(manaTimer());



        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

 
    void Update()
    {
        if(transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x,0,transform.position.y);
        }
        //print(mP);


        mover();
        atacar();

        //status();


    }

    /*void status()
    {
        //mana
        if (mP < 0)
        {
            mP = 0;
        }
        if (mP > 1)
        {
            mP = 1;
        }
        Mana.transform.localScale = new Vector2(mP,1);

    }*/

    void atacar()
    {
        ///Ataque water1
        if(Input.GetKeyDown(KeyCode.X) && Time.time > nextFire && PlayerManaController.playerMana >= 1)
        {
        nextFire = Time.time + fireRate;
        GameObject cloneBullet = Instantiate(bulletOBJ,bulletSpawn.position, bulletSpawn.rotation);
        PlayerManaController.playerMana--;
        }
        ///Ataque sword1
         if(Input.GetKeyDown(KeyCode.C))
        {
        espada.SetActive(true);
        
            
        }
    }

    void mover()
    {
        float yH = Input.GetAxis("Horizontal");
        if(yH != 0 && groundedPlayer){player.SetBool("Move", true);}else{player.SetBool("Move", false);}



        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        ///Movimenta��o Base
        if(!espada.activeSelf){
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), 0);
        controller.Move(move * Time.deltaTime * playerSpeed);
        
        if (move != Vector2.zero)
        {
            gameObject.transform.right = move;
        }
        }
        // Changes the height position of the player..
        if (Input.GetKeyDown(KeyCode.W) && groundedPlayer || Input.GetKeyDown(KeyCode.UpArrow) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


 private void OnTriggerEnter(Collider other) {
         if(other.gameObject.tag == "Garras" && Time.time > nextDamage)
        {
           nextDamage = Time.time + damageRate;
            lifeBar.GetComponent<PlayerLifeController>().playerLife--;
            
            player.SetTrigger("Dano");
            print("Eita");
            
        }
    }
    // IEnumerators

    /*IEnumerator manaTimer()
    {
        while (true)
        {
            if (mP < 1)
            {
                yield return new WaitForSeconds(1f);
                mP += mPRegen;
            }
        }
    }*/
}
