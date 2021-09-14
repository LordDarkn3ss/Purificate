using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    bool playerTocou = false;
    [SerializeField]
    float ElevatorSpeed;
    [SerializeField]
    GameObject uiLifeBar, uiManaBar,SwordUI, text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTocou) { transform.Translate(Vector2.down * ElevatorSpeed * Time.deltaTime); }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerTocou = true;
            uiLifeBar.SetActive(false);
            uiManaBar.SetActive(false);
            SwordUI.SetActive(false);
            text.SetActive(true);
        }
    }
}
