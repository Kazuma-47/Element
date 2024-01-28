using UnityEngine;

public class EndingMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void BackToMenu()
    {
        SceneSwitcher.Instance.BackToMenu();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
