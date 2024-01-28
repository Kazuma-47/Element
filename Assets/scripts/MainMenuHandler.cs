using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Play()
    {
        SceneSwitcher.Instance.SwitchToNextScene();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
