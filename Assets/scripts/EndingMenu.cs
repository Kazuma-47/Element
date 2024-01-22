using UnityEngine;

public class EndingMenu : MonoBehaviour
{
   public void BackToMenu()
    {
        SceneSwitcher.Instance.BackToMenu();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
