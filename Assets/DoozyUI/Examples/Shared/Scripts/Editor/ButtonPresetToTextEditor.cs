using QuickEditor;
using UnityEditor;

namespace DoozyUI
{
    [CustomEditor(typeof(ButtonPresetToText))]
    [CanEditMultipleObjects]
    public class ButtonPresetToTextEditor : QEditor
    {
        ButtonPresetToText Script { get { return (ButtonPresetToText)target; } }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            QUI.Space(SPACE_8);
            if (QUI.Button("Update Text"))
            {
                if (serializedObject.isEditingMultipleObjects)
                {
                    foreach (var t in targets)
                    {
                        ButtonPresetToText s = (ButtonPresetToText)t;
                        s.UpdateTextAndButtonName();
                    }
                }
                else
                {
                    Script.UpdateTextAndButtonName();
                }
            }
        }
    }
}
