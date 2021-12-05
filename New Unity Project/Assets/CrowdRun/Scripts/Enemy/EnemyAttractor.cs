
using UnityEngine;

public class EnemyAttractor : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject[] enemys;
    public GameObject player;
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player"))
        {
            if(enemys != null)
            {
                foreach (GameObject e in enemys)
                {
                    e.transform.position = Vector3.MoveTowards
                    (player.transform.position,e.transform.position,5f*Time.deltaTime);
                }
            }            
        }
    }
}
