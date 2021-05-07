using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Barras Sistema
    [SerializeField]
    Image LifeBar, Mana, Estamina;
    float hP, mP, eP;

    [SerializeField] //ataques
    float waterA1Cust;

    [SerializeField] //Regen
    float mPRegen;

    //Bala
    [SerializeField]
    float bulletVelo;
    public static float bulletSpeed;

    //movimentação
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [SerializeField]
    float playerSpeed = 2.0f;

    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    [SerializeField]
    GameObject tiro, pivotAtirar;


    Rigidbody rb;
    
    void Start()
    {
        //Timers
        StartCoroutine(manaTimer());



        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

 
    void Update()
    {
        bulletSpeed = bulletVelo * 10000;

        //print(mP);


        mover();
        atacar();
        status();


    }

    void status()
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

    }

    void atacar()
    {
        ///Ataque
        if (Input.GetKeyDown(KeyCode.E) && mP>=waterA1Cust)
        {
            Instantiate(tiro, pivotAtirar.transform.position, Quaternion.identity);
            mP -= waterA1Cust;
        }
    }

    void mover()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        ///Movimentação Base
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector2.zero)
        {
            gameObject.transform.right = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


    // IEnumerators

    IEnumerator manaTimer()
    {
        while (true)
        {
            if (mP < 1)
            {
                yield return new WaitForSeconds(1f);
                mP += mPRegen;
            }
        }
    }
}
