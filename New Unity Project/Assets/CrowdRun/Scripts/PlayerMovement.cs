using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class PlayerMovement : MonoBehaviour
{
    [Header("Reference")]
    public Camera mainCam;
    public Animator palyerAnimator;
    public TMP_Text playerCount;
    public GameObject LooseUI;

    [Header("Change Values")]
    public float speed = 0.25f;
    public float swipeSpeed = 10f;
    public float dragSpeed = 5f;
    public bool IsRunning = true;

    //private
    private Transform localTransform;
    private Vector3 lastMousePos;
    private Vector3 mousePos;
    private Vector3 newMousePos;
    private int playerCounts;
    void Start()
    {
        localTransform = GetComponent<Transform>();
    }
    void Update()
    {
        playerCounts = GameObject.FindGameObjectsWithTag("Player").Length;
        playerCount.text = playerCounts.ToString();
        if(playerCounts == 0)
        {
            LooseGame();
        }
        if(IsRunning)
        {
            if(Input.GetMouseButton(0))
            {
                mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,dragSpeed));

                float xDifference = mousePos.x - lastMousePos.x;
                newMousePos.x = localTransform.position.x + xDifference*swipeSpeed*Time.deltaTime;
                newMousePos.x = Mathf.Clamp(newMousePos.x, -0.4f, 0.4f);
                newMousePos.y = localTransform.position.y;
                newMousePos.z = localTransform.position.z;
            
                localTransform.position = newMousePos + localTransform.forward * speed * Time.deltaTime;
                lastMousePos = mousePos;
            }
            else
            {
                localTransform.position += Vector3.forward * Time.deltaTime * speed;
            }
        }
        
    }
    private void LooseGame()
    {
        Time.timeScale = 0;
        LooseUI.SetActive(true);
        Destroy(gameObject);
    }

}
