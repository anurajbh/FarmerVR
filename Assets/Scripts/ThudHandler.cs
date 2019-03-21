using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThudHandler : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        print("Hello there");
    }
    private void OnTriggerExit(Collider other)
    {
        audioSource.Stop();
    }
}
