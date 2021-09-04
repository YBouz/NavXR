using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TargetAnchorRoot))]
public class TargetAnchorRootEditor : Editor
{
    private TargetAnchorRoot _targetAnchorRoot;

    private void OnEnable()
    {
        _targetAnchorRoot = (TargetAnchorRoot) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Refresh"))
        {
            _targetAnchorRoot.Refresh();
        }
    }
}
