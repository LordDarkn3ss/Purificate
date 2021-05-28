using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    [SerializeField]
    GameObject BluePort, RedPort, YellowPort;

    [SerializeField]
    bool BlueKey, RedKey, YellowKey = false;
    
    void Update()
    {
        BluePort.SetActive(!BlueKey);
        RedPort.SetActive(!RedKey);
        YellowPort.SetActive(!YellowKey);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "BlueKey")
        {
            print("PEGOU A CHAVE AZUL");
            BlueKey = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "RedKey")
        {
            print("PEGOU A CHAVE VERMELHA");
            RedKey = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "YellowKey")
        {
            print("PEGOU A ESPADA");
            YellowKey = true;
            Destroy(other.gameObject);
        }
    }
}
