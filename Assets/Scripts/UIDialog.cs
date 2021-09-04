using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIDialog : UIBehavior
{
    [SerializeField]
    private Text m_Text;

    public void SetDialogText(string str)
    {
        if (m_Text)
            m_Text.text = str;
    }
}
