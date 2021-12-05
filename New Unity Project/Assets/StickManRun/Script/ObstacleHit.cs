using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    [SerializeField]private Animator playerAnimator;
    [SerializeField]private PlayerMovementStickMan playerMovementScript;
        
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Collider>().tag == "Obsticals")
        {   
            float x = playerMovementScript.speedX;
            float z = playerMovementScript.speedZ;
            playerAnimator.SetBool("hit",true);
            playerMovementScript.speedZ = 0f;
            playerMovementScript.speedX = 0f;
            // if(System.Math.Abs(x)>System.Math.Abs(z))
            if(x != 0)
            {
                playerMovementScript.ResPlayer(x,false,true);
            }else if(z != 0){
                playerMovementScript.ResPlayer(z,true,false);
            }
            playerMovementScript.gameAudioManager.PlaySound("Respawn");
        }
        
    }
}
