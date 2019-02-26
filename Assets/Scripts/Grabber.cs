using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    [SerializeField] GameObject collidingObject;
    [SerializeField] GameObject objectInHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<>())
        {
            collidingObject = other.gameObject;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        collidingObject = null;
    }	
}
