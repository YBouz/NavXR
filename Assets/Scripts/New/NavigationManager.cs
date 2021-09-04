using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public enum Type
    {
        FirstFloorAnchor,
        SecondFloorAnchor,
        BasementAnchor
    }
    
    [SerializeField] NavMeshAgentController _agentController;
    [SerializeField] private TargetAnchorRoot _firstFloorRoot;
    [SerializeField] private TargetAnchorRoot _secondFloorRoot;
    [SerializeField] private TargetAnchorRoot _basementFloorRoot;

    public List<Transform> FirstFloorAnchors
    {
        get
        {
            return _firstFloorRoot._targetAnchors;
        }
    }
    
    public List<Transform> SecondFloorAnchors
    {
        get
        {
            return _secondFloorRoot._targetAnchors;
        }
    }
    
    public List<Transform> BasementAnchors
    {
        get
        {
            return _basementFloorRoot._targetAnchors;
        }
    }

    public static NavigationManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetAgentTarget(int index, Type type)
    {
        if (_agentController == null)
        {
            Debug.LogError("Agent Controller is null!");
            return;
        }

        switch (type)
        {
            case Type.FirstFloorAnchor:
                if (FirstFloorAnchors[index] != null)
                {
                    _agentController.goal = FirstFloorAnchors[index].transform;
                }

                break;
            case Type.SecondFloorAnchor:
                if (SecondFloorAnchors[index] != null)
                {
                    _agentController.goal = SecondFloorAnchors[index].transform;
                }

                break;
            case Type.BasementAnchor:
                if (BasementAnchors[index] != null)
                {
                    _agentController.goal = BasementAnchors[index].transform;
                }

                break;
        }
    }
}
