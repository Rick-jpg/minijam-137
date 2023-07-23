using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Range(0f, 100f)] private float currentProgress;
    private float maxProgress = 50f;

    private const float ADDEDPROGRESS = 10f;
    private const float REMOVEDPROGRESS = -33f;

    private int rightCounter, wrongCounter;
    [SerializeField] private TMP_Text rightText, wrongText;

    [SerializeField] private Slider slider;

    public delegate void GetScores(int right, int wrong);
    public static GetScores OnGetScores;

    [SerializeField] Animator damageVignette;

    // Start is called before the first frame update
    void Start()
    {
        AddValueToProgress(maxProgress);
    }

    void AddValueToProgress(float addedProgress)
    {
        currentProgress += addedProgress;
        if (currentProgress > 100f) { currentProgress = 100f; }
        if(currentProgress < 0) { currentProgress = 0; }
        slider.value = currentProgress;
    }

    public void AddPositiveToProgress()
    {
        AddValueToProgress(ADDEDPROGRESS);
        rightCounter++;
        UpdateUI();
    }

    public void AddNegativeToProgress()
    {
        AddValueToProgress(REMOVEDPROGRESS);
        wrongCounter++;
        damageVignette.Play("DamageAnimation", -1, 0);
        CheckForGameOver(currentProgress);
        UpdateUI();
    }

    public void TakeDamage()
    {
        AddValueToProgress(REMOVEDPROGRESS);
        CheckForGameOver(currentProgress);
        UpdateUI();
    }

    void CheckForGameOver(float progress)
    {
        if (progress > 0) return;
        GameplayManager.Instance.SpawnGameOverPrefab();
        OnGetScores?.Invoke(rightCounter, wrongCounter);

    }

    void UpdateUI()
    {
        rightText.SetText(rightCounter.ToString());
        wrongText.SetText(wrongCounter.ToString());
    }


}
