using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuManager : MonoBehaviour
{
    [SerializeField] Animator fadeObject;
    [SerializeField] TMP_Text totalText, rightText, wrongText;


    private void OnEnable()
    {
        fadeObject = GameplayManager.Instance.GetFadeAnimator();
        ScoreManager.OnGetScores += SetUI;
    }

    private void OnDisable()
    {
        ScoreManager.OnGetScores -= SetUI;
    }
    public void SetUI(int right, int wrong)
    {
        int total = right + wrong;

        totalText.SetText(total.ToString());
        rightText.SetText(right.ToString());
        wrongText.SetText(wrong.ToString());
    }
    public void GoToMain()
    {
        StartCoroutine(GoBackSequence());
    }

    IEnumerator GoBackSequence()
    {
        fadeObject.Play("FadeAnimationReverse");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
