using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticles : MonoBehaviour
{
    public ParticleSystem particleLauncher;

    public void updatecurrentTimeforStartParticles (float currentTime)
    {
        if (currentTime <= 0)
        {
            print(currentTime);
            particleLauncher.Emit(7);
        }
    }



    void Start()
    {
        
    }

    void Update()
    {
        
        
    }
}
