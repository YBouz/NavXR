using DoozyUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UIElement))]
public class UIBehavior : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnInAnimationsFinished;
    [HideInInspector]
    public UnityEvent OnOutAnimationStart;

    private UIElement _uiElement;
    protected private UIElement uiElement
    {
        get
        {
            if (_uiElement == null)
                _uiElement = this.GetComponent<UIElement>();
            return _uiElement;
        }
    }
    public bool IsShow
    {
        get
        {
            return this.gameObject.activeSelf;
        }
    }

    private void Awake()
    {
        if (uiElement != null)
        {
            uiElement.OnInAnimationsFinish.AddListener(_OnInAnimationsFinish);
            uiElement.OnOutAnimationsStart.AddListener(_OnOutAnimationsStart);
        }
    }

    private void OnDestroy()
    {
        uiElement.OnInAnimationsFinish.RemoveListener(_OnInAnimationsFinish);
        uiElement.OnOutAnimationsStart.RemoveListener(_OnOutAnimationsStart);
    }

    private void _OnInAnimationsFinish()
    {
        OnInAnimationsFinished.Invoke();
    }

    private void _OnOutAnimationsStart()
    {
        throw new NotImplementedException();
    }

    public void Show()
    {
        Debug.Log("Show()");
        uiElement?.Show(true);
        OnShow();
    }

    protected virtual void OnShow()
    {

    }

    public void Hide()
    {
        uiElement?.Hide(true);
    }

    public void ChangeElementName(string str)
    {
        uiElement.elementName = str;
    }
}
