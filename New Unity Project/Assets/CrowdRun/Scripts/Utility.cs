using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject ropeUI;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ropeUI.SetActive(true);
            Destroy(gameObject);
        }
    }
}
