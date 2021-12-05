using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            Handheld.Vibrate();
            Destroy(other.gameObject);
        }
    }
}
