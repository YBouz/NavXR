using UnityEngine;
using UnityEngine.UI;

namespace DoozyUI
{
    public class ButtonPresetToText : MonoBehaviour
    {
        public UIButton button;
        public Text text;
        public bool alsoChangeButtonName = true;

        public TargetPreset targetPreset = TargetPreset.OnClick;

        public enum TargetPreset
        {
            OnPointerEnter,
            OnPointerExit,
            OnPointerDown,
            OnPointerUp,
            OnClick,
            OnDoubleClick,
            OnLongClick,
            NormalLoops,
            SelectedLoops
        }

        private void OnEnable()
        {
            UpdateTextAndButtonName();
        }

        public void UpdateTextAndButtonName()
        {
            if (button == null) { return; }
            string presetName = "None";

            switch (targetPreset)
            {
                case TargetPreset.OnPointerEnter: presetName = button.onPointerEnterPunchPresetCategory + " " + button.onPointerEnterPunchPresetName; break;
                case TargetPreset.OnPointerExit: presetName = button.onPointerExitPunchPresetCategory + " " + button.onPointerExitPunchPresetName; break;
                case TargetPreset.OnPointerDown: presetName = button.onPointerDownPunchPresetCategory + " " + button.onPointerDownPunchPresetName; break;
                case TargetPreset.OnPointerUp: presetName = button.onPointerUpPunchPresetCategory + " " + button.onPointerUpPunchPresetName; break;
                case TargetPreset.OnClick: presetName = button.onClickPunchPresetCategory + " " + button.onClickPunchPresetName; break;
                case TargetPreset.OnDoubleClick: presetName = button.onDoubleClickPunchPresetCategory + " " + button.onDoubleClickPunchPresetName; break;
                case TargetPreset.OnLongClick: presetName = button.onLongClickPunchPresetCategory + " " + button.onLongClickPunchPresetName; break;
                case TargetPreset.NormalLoops: presetName = button.normalLoopPresetCategory + " " + button.normalLoopPresetName; break;
                case TargetPreset.SelectedLoops: presetName = button.selectedLoopPresetCategory + " " + button.selectedLoopPresetCategory; break;
            }

            if (alsoChangeButtonName) { button.name = presetName; }
            if (text != null) { text.text = presetName; }
        }
    }
}
