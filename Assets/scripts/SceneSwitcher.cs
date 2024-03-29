using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    private static SceneSwitcher instance;
    public static SceneSwitcher Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneSwitcher>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("SceneSwitcher");
                    instance = singletonObject.AddComponent<SceneSwitcher>();
                }
            }
            return instance;
        }
    }

    public void SwitchToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

