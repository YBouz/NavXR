using UnityEngine;
using TMPro;
using static UnityEngine.UI.InputField;
using System;
using UnityEngine.UI;
using Michsky.UI.ModernUIPack;
using DoozyUI;

public class UILoginPanel : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;
    private readonly string hideAnimName = "Welcome Out";
    [SerializeField]
    private TMP_InputField m_InputField;
    [SerializeField]
    private UIWelcomeWords m_WelcomeWords;
    [SerializeField]
    private string m_WelcomeTemplateWords = "Hello {0}!<br>Let's take a tour!";
    [SerializeField]
    private Color m_NameColor;
    [SerializeField]
    private ButtonManagerBasic m_ButtonManager;

    public SubmitEvent OnInputEndEdit;
    private string userName;

    private void Awake()
    {
        if (m_InputField != null)
        {
            m_InputField.onEndEdit.AddListener(_onInputEndEdit);
        }

        if (m_ButtonManager != null)
        {
            m_ButtonManager.buttonEvent.AddListener(_OnStartBtnClick);
        }

        m_WelcomeWords?.SetWelcomeWords(string.Empty);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            m_Animator?.Play("Welcome In");
            m_WelcomeWords?.Show();
        }
    }

    private void _OnStartBtnClick()
    {
        m_Animator?.Play(hideAnimName);
        m_WelcomeWords?.Hide();
        GlobalProps.IsLogin = true;
        GlobalProps.UserName = userName;
        gameObject.SetActive(false);
    }

    private void _onInputSelect(string str)
    {
        m_WelcomeWords?.Hide();
    }

    private void _onInputEndEdit(string inputText)
    {
        userName = inputText;
        var clr = ColorUtility.ToHtmlStringRGBA(m_NameColor);
        string colorInput = $"<color=#{clr}>{inputText}</color>";
        string welcomeWords = string.Format(m_WelcomeTemplateWords, colorInput);
        OnInputEndEdit.Invoke(welcomeWords);
        if (!m_WelcomeWords) return;
        if (m_WelcomeWords.IsShow) m_WelcomeWords.Hide();
        if (string.IsNullOrWhiteSpace(inputText)) return;
        m_WelcomeWords.SetWelcomeWords(welcomeWords);
        m_WelcomeWords.Show();
    }
}