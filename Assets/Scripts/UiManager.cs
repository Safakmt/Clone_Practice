using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject restartCanvas;
    [SerializeField] private GameObject finishCanvas;
    [SerializeField] private Slider progresBar;

    [SerializeField] private CanvasGroup startCanvasGroup;
    [SerializeField] private CanvasGroup restartCanvasGroup;
    [SerializeField] private CanvasGroup finishCanvasGroup;


    public void StartCanvasToggle(bool state)
    {
        //startCanvasGroup.alpha = state ? 1 : 0;
        //startCanvasGroup.interactable = state;
        startCanvas.SetActive(state);

        //ActivatePanel(startCanvas);
    }

    public void RestartCanvasToggle(bool state)
    {
        //restartCanvasGroup.alpha = state ? 1 : 0;
        //restartCanvasGroup.interactable = state;

        restartCanvas.SetActive(state);
    }

    public void FinishCanvasToggle(bool state)
    {
        //finishCanvasGroup.alpha = state ? 1 : 0;
        //finishCanvasGroup.interactable = state;
        finishCanvas.SetActive(state);
    }

    public void ProgresBarValues(float min, float max, float value)
    {
        progresBar.minValue = min;
        progresBar.maxValue = max;
        progresBar.value = value;
    }

    public void ProgresBarUpdate(float value)
    {
        progresBar.value = value;
    }

    public void ActivatePanel(GameObject activatedPanel)
    {
        //activatedPanel.enterAnimation
        //lastActivePanel.exitAnimation
        //butun panelleri kapat (genelde butun panelleri listede tutarim)
        activatedPanel.SetActive(true);
    }
}
