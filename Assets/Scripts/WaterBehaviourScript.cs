using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject waterSphere;
    [SerializeField] GameObject lever;
    [SerializeField] Rigidbody waterBody;
    [SerializeField] MeshRenderer water;
    [SerializeField] float dropTime = 3f;
    //[SerializeField] float rotateZ = 3f;
    [SerializeField] float timer = 0f;
    float rotationThisFrame;
    Vector3 startPos;
    //float startLeverRotX;
    //float startLeverRotY;
    //float startLeverRotZ;
    void Start()
    {
        water.enabled = false;
        startPos = waterSphere.transform.position;
        /*startLeverRotX = lever.transform.localRotation.x;
        startLeverRotY = lever.transform.localRotation.y;
        startLeverRotZ = lever.transform.localRotation.z;*/
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //rotationThisFrame = rotateZ * Time.deltaTime;
    }
    public void OnTriggerEnter(Collider other)
    {
        print("Water is flowing");
        if(other.tag == "Player")
        {
            waterBody.useGravity = true;
            waterBody.isKinematic = false;
           // lever.transform.Rotate(startLeverRotX, startLeverRotY, rotateZ);
            Invoke("moveBackToOriginal", dropTime);
        }
    }
    public void moveBackToOriginal()
    {
        water.enabled = true;
        waterBody.useGravity = false;
        waterBody.isKinematic = true;
        waterSphere.transform.position = startPos;
       // lever.transform.Rotate(startLeverRotX, startLeverRotY, startLeverRotZ);
    }

}
