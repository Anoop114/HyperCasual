using UnityEngine;

public class Attractor : MonoBehaviour
{
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player"))
        {
            other.transform.position = Vector3.MoveTowards
            (other.transform.position,transform.position,1f*Time.deltaTime);
        }
    }
}
