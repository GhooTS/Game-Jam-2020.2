using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


[CreateAssetMenu(menuName = "Managers/Scene Manager",fileName = "Scene Manager")]
public class UnitySceneManager : ScriptableObject
{

    public UnityEvent levelLoading;
    public UnityEvent levelLoaded;
    public UnityEvent levelRestaring;
    public UnityEvent levelRestarted;

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void CloseAplication()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
