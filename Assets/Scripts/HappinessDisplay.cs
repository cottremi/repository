using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessDisplay : MonoBehaviour
{
    private int happiness = 5;
    public Text happinessText;

    private PopUp PopUpScript;

    //variables for the eating countdown timer
    float currentTime = 0f;
    float startingTime = 6f;

    private void Awake()
    {
        PopUpScript = GameObject.FindObjectOfType<PopUp>();
    }

    public void updateaffectionPointsforHappinessDisplay(bool affectionPoints)
    {
        if (affectionPoints == true)
        {
            happiness += 1;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        
    }

    // Update is called once per frame
    void Update()
    {

        PopUpScript.UpdateHappinessDisplayforPopUp(happiness);

        happinessText.text = "HAPPINESS: " + happiness;

        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            happiness -= 1;
            currentTime = startingTime;
        }

        if (happiness > 5)
        {
            happiness =5 ;
       
        }

        if (happiness <= 0)
        {
            happiness = 0;
        }
      

    }
}
