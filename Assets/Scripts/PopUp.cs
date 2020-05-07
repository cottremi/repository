using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{

    public Text popUp;

    private bool youDontLoveMe = false;
    private bool iLovedYouButYouDidntLoveMe = false;

    GameObject cube;

   public void UpdateHappinessDisplayforPopUp (int happiness)
    {
        if (happiness == 0)
        {
            youDontLoveMe = true;
        }
        else
        {
            youDontLoveMe = false;
        }
        
    }

    public void updateHungerDisplayforPopUp (int hunger)
    {
       if (hunger == 0 )
        {
            iLovedYouButYouDidntLoveMe = true;
        } 
        else
        {
            iLovedYouButYouDidntLoveMe = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        popUp.enabled = false;

        cube = GameObject.FindGameObjectWithTag("Destroy");
    }

    // Update is called once per frame
    void Update()
    {
        if (youDontLoveMe == true && iLovedYouButYouDidntLoveMe == true)
        {
            popUp.enabled = true;

            Destroy(cube);
        }
    }
}
