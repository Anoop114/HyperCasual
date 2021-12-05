using UnityEngine;
using TMPro;
public class ClonePlayers : MonoBehaviour
{
    [Header("Reference")]
    public GameObject deleteClone;
    public GameObject playerAttractor;
    public GameObject player;
    public TMP_Text countText;
    
    [Header("Change Values")]
    public bool add = false;
    public bool multiply = false;
    public int count = 10;
    
    //private
    private CloningAction palyerCloning;

    void Start()
    {
        palyerCloning = player.GetComponent<CloningAction>();
        if(multiply)
        {
            countText.text = "x"+count.ToString();
        }
        if(add)
        {
            countText.text = "+"+count.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            playerAttractor.SetActive(true);
            if(multiply)
            {
                Handheld.Vibrate();
                palyerCloning.ClonePlayer_Multiply(count);
            }
            if(add)
            {
                Handheld.Vibrate();
                palyerCloning.ClonePlayer_Sum(count);
            }
            playerAttractor.SetActive(false);
            Destroy(deleteClone);
        }
    }
}
