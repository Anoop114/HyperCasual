using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            #if UNITY_ANDROID
                if(Application.platform != RuntimePlatform.WebGLPlayer)
                {
                    Handheld.Vibrate();
                }
            #endif
            Destroy(other.gameObject);
        }
    }
}
