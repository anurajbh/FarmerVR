using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SteamOpenDoor : MonoBehaviour
{
        private Vector3 force;
        private Vector3 cross;
        [SerializeField] bool holdingHandle;
        private float angle;
        private const float forceMultiplier = 150f;
        [SerializeField] SteamVR_Action_Boolean m_GrabAction;
        [SerializeField] GameObject controller;
        private SteamVR_Behaviour_Pose m_Pose = null;

    private void HandHoverUpdate(Hand hand)
        {
            if (m_GrabAction.GetStateDown(m_Pose.inputSource))
            {
                holdingHandle = true;

                // Direction vector from the door's pivot point to the hand's current position
                Vector3 doorPivotToHand = hand.transform.position - transform.parent.position;

                // Ignore the y axis of the direction vector
                doorPivotToHand.y = 0;

                // Direction vector from door handle to hand's current position
                force = hand.transform.position - transform.position;

                // Cross product between force and direction. 
                cross = Vector3.Cross(doorPivotToHand, force);
                angle = Vector3.Angle(doorPivotToHand, force);
            }
            else if (m_GrabAction.GetStateDown(m_Pose.inputSource))
            {
                holdingHandle = false;
            }
        }
    private void Awake()
    {
        m_Pose = controller.GetComponent<SteamVR_Behaviour_Pose>();
    }
    void Update()
        {
            if (holdingHandle)
            {
                // Apply cross product and calculated angle to
                GetComponentInParent<Rigidbody>().angularVelocity = cross * angle * forceMultiplier;
            }
        }

        private void OnHandHoverEnd()
        {
            // Set angular velocity to zero if the hand stops hovering
            GetComponentInParent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
