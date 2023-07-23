using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTime = 10f;
    [SerializeField] private float currentTime;
    [SerializeField] private TMP_Text timerText;

    private const float ADDEDTIME = 12f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameplayManager.Instance.GetGameOver() == true) return;
        currentTime -= Time.deltaTime;
        UpdateText();
    }

    void UpdateText()
    {
        int timer = Convert.ToInt32(currentTime);
        timerText.SetText(timer.ToString());
        if(timer == 0)
        {
            currentTime = startTime;
            GameplayManager.Instance.TakeDamage();
        }
    }

    public void AddToTimer()
    {
        currentTime += ADDEDTIME;
    }
}
