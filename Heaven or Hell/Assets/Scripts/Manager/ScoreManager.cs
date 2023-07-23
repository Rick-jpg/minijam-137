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

    private float addedProgress;
    private const float REMOVEDPROGRESS = -30f;

    private int rightCounter, wrongCounter;
    [SerializeField] private TMP_Text rightText, wrongText;

    [SerializeField] private Slider slider;

    public delegate void GetScores(int right, int wrong);
    public static GetScores OnGetScores;

    [SerializeField] Animator damageVignette;

    [SerializeField] AudioSource musicSource;

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

    public void AddPositiveToProgress(int lawAmount)
    {
        addedProgress = CalculateAddedTime(lawAmount);
        AddValueToProgress(addedProgress);
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
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(1, 4));
    }

    public void TakeDamage()
    {
        AddValueToProgress(REMOVEDPROGRESS);
        damageVignette.Play("DamageAnimation", -1, 0);
        CheckForGameOver(currentProgress);
        UpdateUI();
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(1, 4));
    }

    void CheckForGameOver(float progress)
    {
        if (progress > 0) return;
        GameplayManager.Instance.SpawnGameOverPrefab();
        OnGetScores?.Invoke(rightCounter, wrongCounter);

        musicSource.Stop();
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(1, 5));
    }

    void UpdateUI()
    {
        rightText.SetText(rightCounter.ToString());
        wrongText.SetText(wrongCounter.ToString());
    }

    public float CalculateAddedTime(int lawAmount)
    {
        float difference = (float)6 - (0.5f * lawAmount);
        return difference;
    }


}
