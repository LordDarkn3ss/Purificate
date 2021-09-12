using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    [SerializeField]
    string tag;
    [SerializeField]
    GameObject ativar;
    private void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.tag == tag)
        {
            ativar.SetActive(true);
        }
    }
}
