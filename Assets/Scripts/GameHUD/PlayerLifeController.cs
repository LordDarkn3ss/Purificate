using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerLifeController : MonoBehaviour
{
    public float playerLife, playerLifeMax;
    public Image playerLifeBar;
    public Text playerLifeNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifeBar();
        if(playerLifeBar.fillAmount == 0)
        {
            SceneManager.LoadScene("Area1");
        }
    }

    void UpdateLifeBar()
    {
    playerLifeBar.fillAmount = playerLife / playerLifeMax;
    playerLifeNumber.text = playerLife+"/"+playerLifeMax; 
    }


    
}
