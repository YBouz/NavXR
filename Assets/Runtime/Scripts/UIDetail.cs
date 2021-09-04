using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDetail : UIBehavior
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private String _info;

    private void Start()
    {
        if(_text)
            _text.text = _info;
    }
}
