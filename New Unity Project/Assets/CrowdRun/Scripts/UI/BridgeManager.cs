using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BridgeManager : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject realBridge;
    public TMP_Text bridges;
    public int bridgesCount = 0;
    public PlayerMovement player;

    private int bridgeIncreaser = 0;
    void Start()
    {
        bridges.text = bridgesCount.ToString();
        player.IsRunning = false;
    }

    public void DecreaseBridgeCount()
    {
        Vector3 temp = realBridge.transform.localScale;
        
        if(bridgesCount > 1)
        {
            bridgesCount -= 1;
            bridges.text = bridgesCount.ToString();
            bridgeIncreaser += 1;
            temp.z = bridgeIncreaser;
            realBridge.transform.localScale = temp;
        }else
        {
            player.IsRunning = true;
            Destroy(gameObject);
        }
        
    }

}
