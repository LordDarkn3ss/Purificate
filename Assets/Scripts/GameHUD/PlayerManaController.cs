using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManaController : MonoBehaviour
{
    float nextRegen;


    [SerializeField]
    float mana, manaMax, manaRegen, cooldown;
    public static float playerMana, playerManaMax, playerManaRegen;
    public Image playerManaBar;
    public Text playerManaNumber;
    void Start()
    {
        playerMana = mana;
        playerManaMax = manaMax;
        playerManaRegen = manaRegen;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifeBar();
      
        if (playerMana < playerManaMax && Time.time > nextRegen)
            {
               nextRegen = Time.time + cooldown;
               playerMana+= playerManaRegen;
                
            }
    }

    void UpdateLifeBar()
    {
    playerManaBar.fillAmount = playerMana / playerManaMax;
    playerManaNumber.text = playerMana+"/"+playerManaMax; 
    }
    
    
  
}
