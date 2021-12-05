using UnityEngine;

public class ChangePlayerDir : MonoBehaviour
{
    [SerializeField]private PlayerMovementStickMan playerScript;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "RotateLeft")
        {
            transform.Rotate(0,-90,0);
            playerScript.speedZ = 0f;
            playerScript.speedX = -5f;
        }
        else if(other.GetComponent<Collider>().tag == "RotateLeftNeg")
        {
           transform.Rotate(0,-90,0);
           playerScript.speedZ = -5f;
            playerScript.speedX = 0f;
        }
        else if(other.GetComponent<Collider>().tag == "RotateRight")
        {
           transform.Rotate(0,90,0);
           playerScript.speedZ = 0f;
            playerScript.speedX = 5f;
        }
    }
    



}
