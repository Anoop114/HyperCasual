using UnityEngine;
using System.Collections;
// using UnityEngine.InputSystem;

public class PlayerMovementStickMan : MonoBehaviour
{
    [SerializeField]private Animator playerAnimator;
    [SerializeField]private GameObject audioManage;
    public AudioManagerStickMan gameAudioManager;
    public float speedZ = 5f;
    public float speedX = 0f;
    public float speedY = 0f;
    public bool DirY;
    public Vector3 spawnPointPos;
    private bool touchStart;


    private void Awake()
    {
        gameAudioManager = audioManage.GetComponent<AudioManagerStickMan>();
    }
    public void ResPlayer(float speed,bool dirA,bool dirB)
    {
        StartCoroutine(RespawnPlayer(speed,dirA,dirB));
    }
    private void StartTouch()
    {
        float move = System.Math.Abs(speedX)>System.Math.Abs(speedZ)? System.Math.Abs(speedX) : System.Math.Abs(speedZ);
        playerAnimator.SetFloat("speed",move);
        playerAnimator.SetBool("hit",false);

        if(DirY)
        {
            playerAnimator.SetFloat("climb",speedY);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MovePlayer();
            touchStart = true;
        }else
        {
            touchStart = false;
        }
    }
    private void FixedUpdate() 
    {
        if(touchStart)
        {
            StartTouch();
        }else{
            EndTouch();
        }
    }
    private void MovePlayer()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speedX, transform.position.y + Time.deltaTime * speedY, transform.position.z + Time.deltaTime * speedZ);
    }
    private void EndTouch()
    {
        playerAnimator.SetFloat("speed",0f);
        if(DirY)
        {
            playerAnimator.SetFloat("climb",0f);
        }
    }
   
    private IEnumerator RespawnPlayer(float speed,bool dirA,bool dirB)
    {
        yield return new WaitForSeconds(1.7f);
        playerAnimator.SetBool("hit",false);
        transform.position = spawnPointPos;
        if(dirA)
        {
            speedZ = speed;
        }
        if(dirB)
        {
            speedX = speed;
        }
        
    }
}