using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigarratuTier1HitBox : MonoBehaviour
{
    [SerializeField]
    GameObject parent; //aqui vai ficar o pai do sprite, o cigarratu tem muitos colliders ent assim
                       //eu evito conflitos com os outros colliders 
    float life = 10; // inicial do cigarratu
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider other) { //vai testar se o objeto q o cigarratu colidiu é:
        if(other.gameObject.tag == "Sword")//a Cenourate 
        {
            print("PACADA");
            life-=4;//tira vida do inimigo
            if(life<=0){Destroy(transform.parent.gameObject);} //se a vida do inimigo zerar ele morre
        }
        if(other.gameObject.tag == "Bullet")//a WaterBall
        {
            print("OLHA A ÁGUA");
            Destroy(other.gameObject);//deleta a WaterBall ao contato
            
            life-=2;//Tira vida do inimigo
            if(life<=0){Destroy(transform.parent.gameObject);}//se a vida do inimigo zerar ele morre
            
        }
    }
        
        
}

