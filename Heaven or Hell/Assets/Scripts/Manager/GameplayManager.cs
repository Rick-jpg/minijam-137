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

    private bool isGameOver;
    [SerializeField] private GameObject gameOverPrefab;

    [SerializeField] private Animator fadeAnimator;
    public delegate void ShowLawCreated();
    public static ShowLawCreated OnShowLawCreated;

    public GameplayManager()
    {
        if (Instance != this)
        {
            Instance = this;
        }
    }
    #endregion

    private int roundsAmount;
    public int RoundsAmount { get { return roundsAmount; } }
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

    public void TakeDamage()
    {
        scoreManager.TakeDamage();
    }

    public bool CheckIfPersonIsGuilty(Person newPerson)
    {
        return lawManager.CheckGuilty(newPerson);
    }

    public void CheckToAddNewLaw()
    {
        if (roundsAmount % roundsForNewLaw != 0) return;
            lawManager.MakeNewLaw();
        OnShowLawCreated?.Invoke();
    }

    public void SetGameOver(bool toggle) { isGameOver = false; }
    public bool GetGameOver() { return isGameOver; }
    public void SpawnGameOverPrefab()
    {
        isGameOver = true;
        Instantiate(gameOverPrefab);
    }
    public Animator GetFadeAnimator() { return fadeAnimator; }
    
}
