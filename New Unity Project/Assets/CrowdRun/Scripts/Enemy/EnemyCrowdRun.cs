using UnityEngine;

public class EnemyCrowdRun : MonoBehaviour
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
            Destroy(gameObject);
        }
    }
}
