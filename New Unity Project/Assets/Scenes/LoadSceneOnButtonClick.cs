using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadSceneOnClick(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
