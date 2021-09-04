using Michsky.UI.ModernUIPack;
using UnityEngine;

public class UIDoorPlate : MonoBehaviour
{
    [SerializeField]
    private ButtonManager m_Button;


    public void SetDoorPlateText(string str)
    {
        if (m_Button == null) return;
        m_Button.buttonText = str;
        m_Button.UpdateUI();
    }
}
