using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup ScreenCanvasGroup;
    [SerializeField] protected Button ScreenButton;

    private void OnEnable()
    {
        ScreenButton.onClick.AddListener(OnScreenButtonClick);
    }

    private void OnDisable()
    {
        ScreenButton.onClick.RemoveListener(OnScreenButtonClick);
    }

    protected abstract void OnScreenButtonClick();

    public void Open()
    {
        ScreenCanvasGroup.alpha = 1;
        ScreenButton.interactable = true;
    }

    public void Close()
    {
        ScreenCanvasGroup.alpha = 0;
        ScreenButton.interactable = false;
    }
}
