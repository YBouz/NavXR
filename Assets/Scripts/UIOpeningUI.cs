using UnityEngine;

public class UIOpeningUI : MonoBehaviour
{
    [SerializeField]
    private UILoginPanel m_LoginPanel;

    private void ShowLoginPanel()
    {
        m_LoginPanel.gameObject.SetActive(true);
    }
}
