using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAnchorRoot : MonoBehaviour
{
    [SerializeField] public List<Transform> _targetAnchors = new List<Transform>();

    [SerializeField] public UIDoorPlate _uiDoorPlate;

    private void Awake()
    {
        UpdateDoorPlate();
    }

    private void UpdateDoorPlate()
    {
        if (_uiDoorPlate == null) return;
        foreach (var targetAnchor in _targetAnchors)
        {
            UIDoorPlate plate;
            if (targetAnchor.childCount > 0 && targetAnchor.GetChild(0) != null)
            {
                plate = targetAnchor.GetChild(0).GetComponent<UIDoorPlate>();
                plate.transform.localPosition = Vector3.zero;
            }
            else plate = Instantiate(_uiDoorPlate, transform);
            plate.SetDoorPlateText(targetAnchor.name);
        }
    }

    private void OnDrawGizmos()
    {
        foreach (var targetAnchor in _targetAnchors)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(targetAnchor.position, 0.2f);
        }
    }

    public void Refresh()
    {
#if UNITY_EDITOR
        _targetAnchors.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            _targetAnchors.Add(transform.GetChild(i).transform);
            UpdateDoorPlate();
        }
#endif
    }
}
