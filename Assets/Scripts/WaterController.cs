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
    // Update is called once per frame
    void Update()
    {
        CheckForSolver();
    }

    private void CheckForSolver()
    {
        if(!circularDrive.turnedOff)
        {
            emitter.speed = 0.1f;
        }
        else
        {
            emitter.speed = 0f;
        }
    }

}
