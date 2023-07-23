using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator fadeAnim;

    bool canSelect = true;

    [Header("Variables")]
    [SerializeField] float selectedWaitTime = 1.5f;

    public void StartGame()
    {
        if (!canSelect)
            return;

        StartCoroutine(StartGameSequence());
    }

    IEnumerator StartGameSequence()
    {
        DoFade(true);
        canSelect = false;
        yield return new WaitForSeconds(selectedWaitTime);
        SceneManager.LoadScene(1);
    }

    public void CreditsButton()
    {
        if (!canSelect)
            return;

        StartCoroutine(CreditsSequence());
    }

    IEnumerator CreditsSequence()
    {
        yield return new WaitForSeconds(selectedWaitTime);
    }

    public void Exitgame()
    {
        if (!canSelect)
            return;

        StartCoroutine(ExitgameSequence());
    }

    IEnumerator ExitgameSequence()
    {
        DoFade(true);
        canSelect = false;
        yield return new WaitForSeconds(selectedWaitTime);
        Application.Quit();
    }


    void DoFade(bool reverse)
    {
        if (!reverse)
        {
            fadeAnim.Play("FadeAnimation");
        }
        else
        {
            fadeAnim.Play("FadeAnimationReverse");
        }
    }
}
