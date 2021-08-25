using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigarratoTier1 : MonoBehaviour
{
    public Transform escaner; // o escaner / olho / visão do inimigo
    public float distanciaCheckAbism, speed; // um ranger da visão de abismo e uma variavel de velocidade
    public bool attackRanger, direita; // um BOOL pra saber se o player tá no ranger de ataque, e um pra saber a direção a seguir
    public float life = 3;
    public  Animator tier1; // animator controller do Cigarratu Tier 1

    void Start()
    {
        tier1 = GetComponent<Animator>(); // Recebendo o componente de animator
    }

    
    void Update()
    {
        
            
       
        if(!attackRanger){ //Se não estiver dentro do Ranger de ataque, continue andando
        
         Move(); // movendo
        }
        else
        {
           tier1.SetTrigger("Garra"); //rodar animação de ataque
           attackRanger = false;
            
        }

    }
    void Move()
    {
        if(Physics.Raycast(escaner.position,-escaner.up,distanciaCheckAbism))   //detectar abismo
         {
             Debug.DrawRay(escaner.position,new Vector3(0,-distanciaCheckAbism,0),Color.red);

             
            transform.Translate(Vector2.right * speed * Time.deltaTime); //Movimenta o inimigo           
         }
         else if(direita)
         {
             transform.eulerAngles = new Vector3(0, 180, 0); //girar inimigo
                direita=false;
         }
         else
         {
             transform.eulerAngles = new Vector3(0, 0, 0); //girar inimigo
                direita=true;
         }
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Player") // descobrir que o player está dentro do ranger de ataque
        {
            attackRanger = true; // disse que tá no ranger de ataque
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Sword")
        {
            print("PACADA");
            life--;
            if(life<=0){Destroy(this.gameObject);}
        }
        
    }
}
