using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEatingAnimation : MonoBehaviour
{
    public Animator EatingAnim;

        // Start is called before the first frame update
        void Start()
    {
        EatingAnim = GetComponent<Animator>();
    }

    //plays the EatingAnimation when the berryIsInMouseCollisionBox is TRUE (when the berry is in the box collider on the cubeParent)
    public void updateDragObjectPlayEatingAnimation(bool berryIsInMouseCollisonBox)
    {

        if (berryIsInMouseCollisonBox == true)
        {
            EatingAnim.Play("EatingAnimation");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
