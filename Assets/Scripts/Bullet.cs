using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed, tempoDestroir;//variaveis de velocidade da magia e tempo para sumir;
    void Start()
    {
       Destroy(gameObject,tempoDestroir); //faz a magia sumir depois de um certo tempo
    }

    
    void Update()
    {
      transform.Translate(Vector2.right * speed * Time.deltaTime);  //movimenta a magia no eixo X
    }

    
}
