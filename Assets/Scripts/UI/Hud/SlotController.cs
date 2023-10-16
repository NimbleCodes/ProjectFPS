using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    [SerializeField] GameObject[] _Guns;
    [SerializeField] GameObject[] _slots;
    [SerializeField] GameObject _ammoChecker;
    [SerializeField] Text[] texts;
    GameObject _hud;
    public Vector2 _mousePosNormal;
    public float _currAngle;
    public int _selected;
    int _prevSelection;

    ItemSlot _currSlot;
    ItemSlot _prevSlot;
    GameObject _player = null;
    
    void Start()
    {
        _player = EventManager.events.GetPlayer();
        _hud = EventManager.events.GetHud();
       for(int i =1; i < _Guns.Length;i++){
        _Guns[i].SetActive(false);
       }
    }

    void FixedUpdate()
    {
        if(_player == null) _player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update() {
        _mousePosNormal = new Vector2(Input.mousePosition.x - Screen.width/2f, Input.mousePosition.y - Screen.width/2f);
        // Atan2 음수값 허용
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
            ChangeGun();
            _ammoChecker.GetComponent<AmmoChecker>().SetCurrentWeapon(_selected);
            _hud.GetComponent<HudController>().closeWeaponRing();
        }
    }

    public Text[] GetTexts(){
        return texts;
    }
    void ChangeGun(){
        foreach(GameObject gun in _Guns){
            gun.SetActive(false);
        }

        _Guns[_selected].SetActive(true);
    }
}
