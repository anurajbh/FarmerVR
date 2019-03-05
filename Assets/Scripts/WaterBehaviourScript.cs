using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject waterSphere;
    [SerializeField] Rigidbody waterBody;
    [SerializeField] MeshRenderer water;
    Vector3 startPos;
    void Start()
    {
        water.enabled = false;
        startPos = waterSphere.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        print("Water is flowing");
        if(other.tag == "Player")
        {
            waterBody.useGravity = true;
            waterBody.isKinematic = false;
            Invoke("moveBackToOriginal", 5f);
            
        }
    }
    public void moveBackToOriginal()
    {
        water.enabled = true;
        waterBody.useGravity = false;
        waterBody.isKinematic = true;
        waterSphere.transform.position = startPos;
    }

}
