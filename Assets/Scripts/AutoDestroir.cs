using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroir : MonoBehaviour
{
    [SerializeField]
    bool menuAnim;
    void Start()
    {
        if (menuAnim)
        {
            Destroy(this.gameObject, 6f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void autoDestroir()
    {
        Destroy(this.gameObject);
    }
}
