using UnityEngine;
using TMPro;

public class TutorialQuest : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] QuestIndicators = new ParticleSystem[4];
    private int currentQuest = 0;
    private PlayerUiHandler playerObjective;
    void Start()
    {
        playerObjective = PlayerSpawner.playerInstance.GetComponent<PlayerUiHandler>();
        Quest1();
    }
    
    
    public void NextQuest()
    {
        currentQuest += 1;
        switch (currentQuest)
        {
            case 1:
                Quest2();
                break;
            case 2:
                Quest3();
                break;
            case 3:
                Quest4();
                break;
            case 4:
                ExitQuest();
                break;

        }
        if (currentQuest != 4)
        NextQuestIndicator();
    }
    private void NextQuestIndicator()
    {
        QuestIndicators[currentQuest].GetComponent<NextQuestIndicator>().Active = true;
        QuestIndicators[currentQuest - 1].GetComponent<NextQuestIndicator>().Active = false;
        QuestIndicators[currentQuest - 1].Stop();
        QuestIndicators[currentQuest].Play();
    }
    #region Quests
    private void Quest1()
    {
        playerObjective.setObjective("Try the first ability spawner.");
        QuestIndicators[currentQuest].GetComponent<NextQuestIndicator>().Active = true;
    }
    private void Quest2()
    {
        playerObjective.setObjective("Manipulate the object size using the next ability.");
    }
    private void Quest3()
    {
        playerObjective.setObjective("Manipulate the object size using the next ability.");
    }
    private void Quest4()
    {
        playerObjective.setObjective("Manipulate the objects gravity using the next ability");
    }
    private void ExitQuest()
    {
        playerObjective.setObjective("Once you are ready head to the indicated area to start level 1");
        QuestIndicators[currentQuest - 1].Stop();
        QuestIndicators[currentQuest].Play();
    }

    #endregion
}
