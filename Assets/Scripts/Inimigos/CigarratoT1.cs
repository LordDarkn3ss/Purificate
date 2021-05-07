using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigarratoT1 : MonoBehaviour
{
    [SerializeField]
    float velocidade, distancia;
    [SerializeField]
    LayerMask obstaculo;
    bool direita = true; //indica a direção ao qual se mover
    public Transform escaner;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime); //Movimenta o inimigo
        RaycastHit2D piso = Physics2D.Raycast(escaner.position, Vector3.down, distancia, obstaculo); //Checar Queda, desviar rota
        Debug.DrawRay(escaner.position, Vector3.down,Color.red);

        if(piso.collider==false) //se abismo a frente
        {
            if(direita==true)//se estiver para a direita
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                direita = false;
                print("direitaFalse");
            }
            else //mudar direção
            {
                transform.eulerAngles = new Vector3(0, 180, 0); //girar inimigo mudando direção
                direita = true;
                print("direitaTrue");
            }
        }
    }
}
