using TMPro;
using UnityEngine;

public class PlayerUiHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missionObjective;
    [SerializeField] private TextMeshProUGUI missionName;
    [SerializeField] private GameObject interactionPrompt;
    public void setObjective(string Objective)
    {
        missionObjective.text = Objective;
    }
    public void SetMissionName(string name)
    {
        missionName.text = "Mission: " +name;
    }
    public void ToggleInterActionPrompt(bool toggle)
    {
        interactionPrompt.SetActive(toggle);
    }
}
