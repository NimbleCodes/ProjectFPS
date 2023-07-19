using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Color _hoverColor;
    [SerializeField] Color _baseColor;
    [SerializeField] Image _backGround;
    [SerializeField] Image _weaponImg;
    private void Start() {
        _backGround.color = _baseColor;
    }

    public void Select(){
        _backGround.color = _hoverColor;
    }

    public void Deselect(){
        _backGround.color = _baseColor;
    }

    public string getWeaponName(){
        return _weaponImg.name;
    }
}
