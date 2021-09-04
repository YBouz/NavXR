using Michsky.UI.ModernUIPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UILocationManager : UIBehavior
{
    [SerializeField] private CustomDropdown _dropdownList;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Toggle _firstFloorToggle;
    [SerializeField] private Toggle _secondFloorToggle;
    [SerializeField] private Toggle _basementToggle;

    private void Awake()
    {
        if (_firstFloorToggle)
            _firstFloorToggle.onValueChanged.AddListener(OnToggleSelected);
        if (_secondFloorToggle)
            _secondFloorToggle.onValueChanged.AddListener(OnToggleSelected);
        if (_basementToggle)
            _basementToggle.onValueChanged.AddListener(OnToggleSelected);
        
        if(_dropdownList)
            _dropdownList.dropdownEvent.AddListener(_OnDropdownEvent);
        
        //RefreshDropdownList();
    }

    private void OnDestroy()
    {
        if(_firstFloorToggle)
            _firstFloorToggle.onValueChanged.RemoveListener(OnToggleSelected);
        
        if(_secondFloorToggle)
            _secondFloorToggle.onValueChanged.RemoveListener(OnToggleSelected);
        
        if (_basementToggle)
            _basementToggle.onValueChanged.RemoveListener(OnToggleSelected);
        
        if(_dropdownList)
            _dropdownList.dropdownEvent.RemoveListener(_OnDropdownEvent);
    }

    private void OnToggleSelected(bool isOn)
    {
        RefreshDropdownList();
        _dropdownList.SetupDropdown();
        _dropdownList.UpdateValues();
    }
    
    public void _OnDropdownEvent(int index)
    {
        OnSelectLocation(_dropdownListMap[index].Key, _dropdownListMap[index].Value);
    }

    private void RefreshDropdownList()
    {
        if (_dropdownList)
        {
            _dropdownList.dropdownItems = _GetItemList();
        }
    }
    
    private Dictionary<int, KeyValuePair<int, NavigationManager.Type>> _dropdownListMap;

    private List<CustomDropdown.Item> _GetItemList()
    {
        List<CustomDropdown.Item> targetList = new List<CustomDropdown.Item>();
        _dropdownListMap = new Dictionary<int, KeyValuePair<int, NavigationManager.Type>>();

        if (_firstFloorToggle.isOn)
        {
            var list = _CreateItemList(NavigationManager.Instance.FirstFloorAnchors);
            UpdateDropdownMap(list.Count, targetList.Count, NavigationManager.Type.FirstFloorAnchor);
            targetList.AddRange(list);
        }
        
        if (_secondFloorToggle.isOn)
        {
            var list = _CreateItemList(NavigationManager.Instance.SecondFloorAnchors);
            UpdateDropdownMap(list.Count, targetList.Count, NavigationManager.Type.SecondFloorAnchor);
            targetList.AddRange(list);
        }
        
        if (_basementToggle.isOn)
        {
            var list = _CreateItemList(NavigationManager.Instance.BasementAnchors);
            UpdateDropdownMap(list.Count, targetList.Count, NavigationManager.Type.BasementAnchor);
            targetList.AddRange(list);
        }

        _dropdownList.selectedItemIndex = 0;
        return targetList;
    }

    private void UpdateDropdownMap(int listCount, int targetListCount, NavigationManager.Type type)
    {
        int index = targetListCount;
        for (int i = 0; i < listCount; i++)
        {
            _dropdownListMap.Add(index, new KeyValuePair<int, NavigationManager.Type>(i, type));
            index++;
        }
    }
    
    private List<CustomDropdown.Item> _CreateItemList(List<Transform> list)
    {
        List<CustomDropdown.Item> _list = new List<CustomDropdown.Item>();
        for (int i = 0; i < list.Count; i++)
        {
            var l = list[i];
            if (l == null) continue;
            var item = new CustomDropdown.Item
            {
                itemName = l.gameObject.name,
                itemIcon = _sprite,
            };
            _list.Add(item);
        }
        return _list;
    }
    
    private async void OnSelectLocation(int index, NavigationManager.Type type)
    {
        Hide();
        await Task.Delay(700);
        NavigationManager.Instance.SetAgentTarget(index, type);
    }
}
