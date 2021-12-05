using UnityEngine;

public class WinGame : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject WinUI;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            WinUI.SetActive(true);       
        }
    }
}
