using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    #region Managers References
    [SerializeField] private CharacterManager characterManager;
    [SerializeField] private LawManager lawManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Timer timer;
    #endregion
    #region Singleton
    public static GameplayManager Instance;

    public GameplayManager()
    {
        if (Instance != this)
        {
            Instance = this;
        }
    }
    #endregion

    private int roundsAmount;
    private int startLaws = 2;

    private int roundsForNewLaw = 8;

    private void Start()
    {
        lawManager.SetupLaws(startLaws);
        characterManager.SetMaxCounts();
        characterManager.GeneratePerson();
    }

    public void CheckIfGuilty(bool isSentToHeaven)
    {
        bool isGuilty = characterManager.CurrentPerson.GetGuilty();
        if(isGuilty != isSentToHeaven)
        {
            AddScore();
        }
        else
        {
            RemoveScore();
        }
        roundsAmount++;
        CheckToAddNewLaw();
    }

    private void AddScore()
    {
        scoreManager.AddPositiveToProgress();
        timer.AddToTimer();
    }

    public void RemoveScore()
    {
        scoreManager.AddNegativeToProgress();
    }

    public bool CheckIfPersonIsGuilty(Person newPerson)
    {
        return lawManager.CheckGuilty(newPerson);
    }

    public void CheckToAddNewLaw()
    {
        if (roundsAmount % roundsForNewLaw != 0) return;
            lawManager.MakeNewLaw();
    }
    
}
