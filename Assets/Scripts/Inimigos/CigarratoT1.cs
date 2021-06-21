using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigarratoT1 : MonoBehaviour
{
    float a; //velocidade inicial
    float b;

    [SerializeField]
    float velocidade,investidaVelo, distanciaCheckAbism, distanciaCheckParede, distanciaVision, vida;
    [SerializeField]
    LayerMask obstaculo;
    bool direita = true; //indica a direção ao qual se mover
    bool vendoPlayer = false; //indica se o player está no campo de visão
    public Transform escaner;
    public Transform escanerA;
    public Transform escanerB;
    public Transform escanerC;
    public Transform escanerD;

    

    void Start()
    {
        vida = 2;
      a = velocidade;
    }

    // Update is called once per frame
    void Update()
    {

        if(direita){b = 1;}else{b=-1;}

        if(vida <= 0)
        {
            Destroy(this.gameObject);
        }
        scanAbismo();
        //scanVision();
       
        //scanParede(escanerA);
        //scanParede(escanerB);
        scanParede(escanerC);
        //scanParede(escanerD);

        
    }
    void scanAbismo()
    {
    //scan para abismo 
        if(Physics.Raycast(escaner.position,-escaner.up,distanciaCheckAbism))//detectar abismo
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime); //Movimenta o inimigo
            
        }
        else if(direita && !vendoPlayer)
        {
            
                transform.eulerAngles = new Vector3(0, 180, 0); //girar inimigo
                direita=false;
  
        }
        else if(!vendoPlayer)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); //girar inimigo
                direita=true;
        }
        Debug.DrawLine(escaner.position,new Vector3(escaner.position.x,escaner.position.y - distanciaCheckAbism,escaner.position.z),Color.red);
        
        

    }
    void scanParede(Transform altura)
    {
        //scan pra paredes
        RaycastHit hit = new RaycastHit();
        if(Physics.Raycast(altura.position,b*altura.forward,out hit,distanciaCheckParede,obstaculo))//detectar paredes
        {
            print("parede");
        if(direita)
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
        
        Debug.DrawLine(altura.position,new Vector3(altura.position.x+(distanciaCheckParede*b),altura.position.y ,altura.position.z),Color.green);
    }

    void scanVision()
    {
    //scan para o player
        RaycastHit ver;
        if(Physics.Raycast(escaner.position,escaner.forward,out ver,distanciaVision))
        {
            
              if(ver.transform.tag == "Player") //vê se o raycast tocou no player
              {
                 
               velocidade = investidaVelo;//adiciona a investida
               vendoPlayer = true; //faz ignorar abismos
              }
              else
              {
                  velocidade = a; //retorna velocidade inicial
                  vendoPlayer = false; //não está vendo o player então volta a ver os abismos
              }
        }
        if(direita){
        Debug.DrawLine(escaner.position,new Vector3(escaner.position.x+distanciaVision,escaner.position.y,escaner.position.z),Color.red);
        }
        else{
            Debug.DrawLine(escaner.position,new Vector3(escaner.position.x-distanciaVision,escaner.position.y,escaner.position.z),Color.red);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Sword" || other.gameObject.tag == "WaterBall")
        {
            vida--;
        }
    }
}
