using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuManager : MonoBehaviour
{
    [SerializeField] Animator fadeObject;

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
