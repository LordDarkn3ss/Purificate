using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Barras Sistema
    [SerializeField]
    Image LifeBar, Mana, Estamina;

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
    // Start is called before the first frame update
    void Start()
    {
       
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletSpeed = bulletVelo * 10000;
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

        

        ///Ataque
        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(tiro, pivotAtirar.transform.position,Quaternion.identity);
        }

    }
}
