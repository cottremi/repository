using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerDisplay : MonoBehaviour
{
    private int hunger = 6;
    public Text hungerText;

    float currentTime = 0f;
    float startingTime = 9f;

    private PopUp PopUpScript;

    private void Awake()
    {
        PopUpScript = GameObject.FindObjectOfType<PopUp>();
    }

    public void updatehasEatenBerryforHungerDisplay(bool hasEatenBerry)
    {
        if (hasEatenBerry == true)
        {
            hunger += 1;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PopUpScript.updateHungerDisplayforPopUp(hunger);

        hungerText.text = "HUNGER: " + hunger;

        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            hunger -= 1;
            currentTime = startingTime;
        }

        if (hunger > 5)
        {
            hunger = 5;

        }

        if (hunger <= 0)
        {
            hunger = 0;
  
        }
       
    }
}
