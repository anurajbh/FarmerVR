using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Obi;
using Valve.VR.InteractionSystem;
using System;

public class WaterController : MonoBehaviour
{
    public CircularDrive circularDrive;
    public Obi.ObiEmitter emitter;
    AudioSource audi;
    // Update is called once per frame
    private void Start()
    {
        audi = GetComponent<AudioSource>();
    }
    void Update()
    {
        CheckForSolver();
    }

    private void CheckForSolver()
    {
        if(!circularDrive.turnedOff)
        {
            if (!audi.isPlaying)
            {
                audi.Play();
            }

            emitter.speed = 0.1f;
        }
        else if(circularDrive.turnedOff)
        {
            audi.Stop();
            emitter.speed = 0.0f;
        }
        if(emitter.radhaIsActive)
        {
            audi.Stop();
        }
    }

}
