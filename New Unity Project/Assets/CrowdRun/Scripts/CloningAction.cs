using UnityEngine;

public class CloningAction : MonoBehaviour
{
    [Header("Reference")]
    public GameObject parentObject;
    public GameObject clonePlayer;
    
    //private
    private Transform playerTransform;
    private int currentPlayerCount;
    float transformPlayerX;
    float transformPlayerY;
    float transformPlayerZ;
    Vector3 transformPlayer;
    void Start()
    {
        playerTransform = clonePlayer.GetComponent<Transform>();
    }
    public void ClonePlayer_Multiply(int multiply)
    {
        currentPlayerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        multiply = multiply*currentPlayerCount;
        for (int i = 0; i < multiply; i++)
        {
            transformPlayerX = playerTransform.position.x+Random.Range(-0.2f,0.2f);
            transformPlayerY = playerTransform.position.y;
            transformPlayerZ = playerTransform.position.z+Random.Range(0.05f,0.3f);
            transformPlayer = new Vector3(transformPlayerX,transformPlayerY,transformPlayerZ);
            GameObject childObject = Instantiate(clonePlayer,transformPlayer, Quaternion.identity) as GameObject;
            childObject.transform.parent = parentObject.transform;
        }
        
    }

    public void ClonePlayer_Sum(int count)
    {
        for (int i = 0; i < count; i++)
        {
            transformPlayerX = playerTransform.position.x+Random.Range(-0.2f,0.2f);
            transformPlayerY = playerTransform.position.y;
            transformPlayerZ = playerTransform.position.z+Random.Range(0.05f,0.3f);
            transformPlayer = new Vector3(transformPlayerX,transformPlayerY,transformPlayerZ);
            GameObject childObject = Instantiate(clonePlayer,transformPlayer, Quaternion.identity) as GameObject;
            childObject.transform.parent = parentObject.transform;
        }
    }
}
