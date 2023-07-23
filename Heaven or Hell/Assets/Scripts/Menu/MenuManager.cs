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
    [SerializeField] Animator tutorialCanvas;

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
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(0, 1));
        yield return new WaitForSeconds(selectedWaitTime);
        SceneManager.LoadScene(1);
    }

    public void TutorialButton()
    {
        if (!canSelect)
            return;

        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(0, 1));
        tutorialCanvas.Play("TutorialPopup");
    }

    public void EndTutorialButton()
    {
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(0, 1));
        tutorialCanvas.Play("TutorialPopdown");
        canSelect = true;
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
        Audiomanager.instance.PlaySound(Audiomanager.instance.GetSound(0, 1));
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
