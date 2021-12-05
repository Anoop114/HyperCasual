using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyCounter : MonoBehaviour
{
    [Header("Refrance")]
    public TMP_Text enemyCounts;
    public string enemyTag;
    private int enemyCount;
    void FixedUpdate()
    {
        enemyCount = GameObject.FindGameObjectsWithTag(enemyTag).Length;
        enemyCounts.text = enemyCount.ToString();
        if(enemyCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
