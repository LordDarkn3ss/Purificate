using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    [SerializeField]
    GameObject BluePort, RedPort, YellowPort; //chaves para o inventario

    [SerializeField]
    bool BlueKey, RedKey, YellowKey = false; //inicia com o inventario vazio
    
    void Update()
    {
        BluePort.SetActive(!BlueKey); //Testa se você tem a chave e abre o portão correspondente a ela /AZUL
        RedPort.SetActive(!RedKey);//Testa se você tem a chave e abre o portão correspondente a ela /VERMELHA
        YellowPort.SetActive(!YellowKey);//Testa se você tem a chave e abre o portão correspondente a ela /AMARELA
    }

    private void OnTriggerEnter(Collider other) { //Vê se você colidiu com a chave para por no inventario
        if(other.gameObject.tag == "BlueKey") //você pegou a chave azul
        {
            print("PEGOU A CHAVE AZUL");
            BlueKey = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "RedKey") //você pegou a chave vermelha
        {
            print("PEGOU A CHAVE VERMELHA");
            RedKey = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "YellowKey") //você pegou a "chave amarela", cenourate serve para abrir portões de bosses
        {
            print("PEGOU A ESPADA");
            YellowKey = true;
            Destroy(other.gameObject);
        }
    }
}
