using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radhaBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] otherRadha;

    void Awake()
    {
        //kill other instances of Radha
        otherRadha[0].SetActive(false);
        otherRadha[1].SetActive(false);
    }
}
