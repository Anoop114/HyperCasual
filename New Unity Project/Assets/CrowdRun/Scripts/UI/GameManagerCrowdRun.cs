using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerCrowdRun : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
}
