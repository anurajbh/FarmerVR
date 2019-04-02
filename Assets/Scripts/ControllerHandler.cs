using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerHandler : MonoBehaviour
{
    [SerializeField] SteamVR_Action_Boolean m_GrabAction;
    public bool pickedUp = false;
    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;//fixed joint to attach the interactable to
    Rigidbody targetBody;
    private InteractionHandler m_CurrentInteractable = null;

    //List of interactables in contact
    [SerializeField] List<InteractionHandler> m_ContactInteractables = new List<InteractionHandler>();

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    private void Update()
    {
        //On pressing action
        if(m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            Pickup();
        }
        //on Letting go of action
        if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            Drop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //null check
        if (!other.gameObject.CompareTag("Interactable"))
            return;
        //add to Current Interactable List
        m_ContactInteractables.Add(other.gameObject.GetComponent<InteractionHandler>());

    }
    private void OnTriggerExit(Collider other)
    {
        //null check
        if (!other.gameObject.CompareTag("Interactable"))
            return;
        //remove from Current Interactable List
        m_ContactInteractables.Remove(other.gameObject.GetComponent<InteractionHandler>());
    }
    public void Pickup()
    {
        //get nearest
        m_CurrentInteractable = GetNearestInteractable();
        //check if null
        if (!m_CurrentInteractable)
            return;
        //check if already held
        if (m_CurrentInteractable.m_CurrentHand)
            m_CurrentInteractable.m_CurrentHand.Drop();
        //Position
        m_CurrentInteractable.transform.position = transform.position;
        //Attach
        targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;
        //Set active hand
        m_CurrentInteractable.m_CurrentHand = this;
        pickedUp = true;
    }
    public void Drop()
    {
        //check if null
        if (!m_CurrentInteractable)
            return;
        //Drop Velocity
        targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = m_Pose.GetVelocity();
        targetBody.angularVelocity = m_Pose.GetAngularVelocity();
        //Detach
        m_Joint.connectedBody = null;

        //Clear
        m_CurrentInteractable.m_CurrentHand = null;
        m_CurrentInteractable = null;

    }
    private InteractionHandler GetNearestInteractable()
    {
        InteractionHandler nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;
        foreach(InteractionHandler interactable in m_ContactInteractables)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;
            if(distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }  
        return nearest;
    }
}
