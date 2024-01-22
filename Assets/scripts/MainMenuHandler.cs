using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    public void Play()
    {
        SceneSwitcher.Instance.SwitchToNextScene();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
