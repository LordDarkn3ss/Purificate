using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    CigarratoTier1 pai;
    [SerializeField]
    GameObject paiTransform;
    void Awake()
    {
       pai = GetComponentInParent<CigarratoTier1>();
       

    }

    
    void Update()
    {
        print(paiTransform.transform.eulerAngles.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstaculo")
        {
        
        print("COLIDIU EM");
           
           if(pai.direita)
         {
             paiTransform.transform.eulerAngles = new Vector3(0, 180, 0); //girar inimigo
                pai.direita=false;
         }
         else
         {
             paiTransform.transform.eulerAngles = new Vector3(0, 0, 0); //girar inimigo
                pai.direita=true;
         }
            
        }
    }

    
}
