using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour
{
    Animator _anim;
    public Text _animClipName;
    public GameObject _player;
    string _currentClipName;
    AnimatorClipInfo[] _currentClipInfo;

    void Start()
    {
        _anim = _player.GetComponent<Animator>();
    }

    public void next()
    {
        _anim.SetTrigger("ToNext");
    }
    public void previous()
    {
        _anim.SetTrigger("ToPrevious");
    }

    void OnGUI()
    {
        _currentClipInfo = _anim.GetCurrentAnimatorClipInfo(1);
        _currentClipName = _currentClipInfo[0].clip.name;
        _animClipName.text = _currentClipName;
    }
}
