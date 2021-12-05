using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Refrance")]
    public Image timer;
    public float totalTime = 0;
    public PlayerMovement player;

    private float currentTime;
    void Start()
    {
        currentTime = totalTime;
    }
    private void FixedUpdate()
    {
        if(totalTime > 0 )
        {
            totalTime -= Time.deltaTime;
            timer.fillAmount = totalTime/currentTime;
        }else
        {
            player.IsRunning = true;
            Destroy(gameObject);
        }
    }
}
