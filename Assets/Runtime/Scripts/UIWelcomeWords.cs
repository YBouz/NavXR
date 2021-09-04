using UnityEngine;

public class UIWelcomeWords : UIBehavior
{
    [SerializeField]
    private TMPro.TextMeshProUGUI m_Text;

    public void SetWelcomeWords(string str)
    {
        if (m_Text)
            m_Text.text = str;
    }
}
