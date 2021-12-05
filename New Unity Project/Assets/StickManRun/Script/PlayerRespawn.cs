using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]private PlayerMovementStickMan setSpawnPoint;
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Collider>().tag == "Respawn")
        {
            setSpawnPoint.spawnPointPos = other.transform.position;
        }
    }
}
