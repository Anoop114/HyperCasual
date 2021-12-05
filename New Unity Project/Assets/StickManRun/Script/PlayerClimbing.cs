using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{
    [SerializeField]private PlayerMovementStickMan playerClimb;
    [SerializeField]private Animator playerAnimator;
    private float xSpeed = 0f;
    private float zSpeed = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Climb")
        {
            xSpeed = playerClimb.speedX;
            zSpeed = playerClimb.speedZ;
            GetComponent<Rigidbody>().useGravity = false;
            playerClimb.speedY = 1f;
            playerClimb.DirY = true;
            playerClimb.speedZ = 0f;
            playerClimb.speedX = 0f;
        }
        if(other.GetComponent<Collider>().tag == "ClimbOver")
        {
            playerClimb.DirY = false;
            playerAnimator.SetFloat("climb",0f);
            playerClimb.speedY = 0f;
            GetComponent<Rigidbody>().useGravity = true;
            playerClimb.speedZ = zSpeed;
            playerClimb.speedX = xSpeed;
        }
    }
    // private void OnCollisionStay(Collision other) 
    // {
    //     if(other.gameObject.CompareTag("Climb"))
    //     {
    //         xSpeed = playerClimb.speedX;
    //         zSpeed = playerClimb.speedZ;
    //         playerClimb.speedY = 5f;
    //         playerClimb.speedZ = 0f;
    //         playerClimb.speedX = 0f;
    //     }
    // }

}
