using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerWin : MonoBehaviour
{
    [SerializeField]private Animator playerAnimator;
    [SerializeField]private PlayerMovementStickMan playerSpeed;
    [SerializeField]private CinemachineVirtualCamera VCam4;
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Collider>().tag == "Finish")
        {
            playerAnimator.SetBool("win"+Random.Range(1,6).ToString(),true);
            VCam4.Priority = 5;
            playerSpeed.speedZ = 0f;
            playerSpeed.speedX = 0f;
            playerSpeed.gameAudioManager.StopSound("Theme");
            playerSpeed.gameAudioManager.PlaySound("Win");
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(3f);
        playerSpeed.gameAudioManager.StopSound("Win");
        yield return new WaitForSeconds(5f);
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextScene <= 3)
        {
            SceneManager.LoadScene(nextScene);
        }else
        {
            yield return null;
        }
    }
}
