using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlotController : MonoBehaviour
{
    [SerializeField]  GameObject[] _slots;
    public Vector2 _mousePosNormal;
    public float _currAngle;
    public int _selected;
    int _prevSelection;

    ItemSlot _currSlot;
    ItemSlot _prevSlot;
    
    private void Update() {
        _mousePosNormal = new Vector2(Input.mousePosition.x - Screen.width/2.5f, Input.mousePosition.y - Screen.width/2.5f);
        _currAngle = Mathf.Atan2(_mousePosNormal.y, _mousePosNormal.x) * Mathf.Rad2Deg;
        _currAngle = (_currAngle + 360)%360;
        _selected = (int)_currAngle/90;
        
        if(_selected != _prevSelection){
            _prevSlot = _slots[_prevSelection].GetComponent<ItemSlot>();
            _prevSlot.Deselect();
            _prevSelection = _selected;

            _currSlot = _slots[_selected].GetComponent<ItemSlot>();
            _currSlot.Select();
        }

        if(Input.GetMouseButtonDown(0)){
            string weaponName = _currSlot.getWeaponName();
        }
    }
}
