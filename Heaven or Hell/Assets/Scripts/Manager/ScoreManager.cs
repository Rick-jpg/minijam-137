using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Range(0f, 100f)] private float currentProgress;
    private float maxProgress = 100f;

    private const float ADDEDPROGRESS = 10f;
    private const float REMOVEDPROGRESS = -33f;

    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        AddValueToProgress(maxProgress);
    }

    void AddValueToProgress(float addedProgress)
    {
        currentProgress += addedProgress;
        slider.value = currentProgress;
    }

    [ContextMenu("Add")]
    void AddPositiveToProgress()
    {
        AddValueToProgress(ADDEDPROGRESS);
    }

    [ContextMenu("Remove")]
    void AddNegativeToProgress()
    {
        AddValueToProgress(REMOVEDPROGRESS);
    }


}
