using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private Slider _dashCdslider;
    [SerializeField] private float _maxSpeed, _speed;
    [SerializeField] private Transform _playerdir;
    [SerializeField] private float _drag;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashUpForce;
    private float dashCoolTime = 0.25f;
    [SerializeField] Text text;
    const float ticktime = 0.1f;
    float ticktimer;
    Rigidbody _rig;
    Vector3 _direction,_delayForce;
    public bool _isOnGround=false, _isDash=false, _isDashOnCd = false,_turnMomentum = false;
    float _playerHeight =2f;
    float x, z; //Movement Velocity value
    
    void Start()
    {
        _rig = GetComponent<Rigidbody>();
        _rig.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        _direction = _playerdir.forward * z + _playerdir.right * x;
        _rig.AddForce(_direction.normalized * _speed * 10f, ForceMode.Force);

    }

    private void Update()
    {
        _isOnGround = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.3f, Ground);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround == true)
        {
            _rig.AddForce(Vector3.up * 6, ForceMode.Impulse);
        }

        if(_isOnGround){
            _rig.drag = _drag;
        }else{
            _rig.drag = 0f;
        }
        LimitSpeed();
        ShowDashCoolTime();
    }

    void Dash(){
        if(_isDashOnCd && _dashCdslider.value < 1) return;
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            _isDash = true;
            _isDashOnCd = true;
            _turnMomentum = true;
            _dashCdslider.value -= 1f;
            _maxSpeed = 30;
            _rig.useGravity = false;
            _rig.drag =0;
            Vector3 forceToApply = _direction.normalized * dashForce + transform.up * dashUpForce;
            _rig.AddForce(forceToApply, ForceMode.Impulse);

            Invoke("DelayForce", 0.025f);
            StopCoroutine(LerpMoveSpeed());
            StartCoroutine(LerpMoveSpeed());
            Invoke("ResetDash", dashCoolTime);
            
        }
    }

    void ShowDashCoolTime(){ // restore cooldown by 0.1 every 0.1 sec
        if(!_isDashOnCd) return;
        ticktimer += Time.deltaTime;
        if(ticktimer >= ticktime){
            ticktimer -= ticktime;
            _dashCdslider.value += 0.1f;
            text.text =  (int)_dashCdslider.value + " / 2";
        }

        if(_dashCdslider.value >= 2f){
            _isDashOnCd = false;
        }
    }


    void DelayForce(){ // force delay to avoid dash force to player movement
        _rig.AddForce(_delayForce,ForceMode.Impulse);
    }
    void ResetDash(){
        _isDash = false;
        _rig.useGravity = true;
        _rig.drag = _drag;
    }
    void LimitSpeed(){
        Vector3 flatValue = new Vector3(_rig.velocity.x, 0f, _rig.velocity.z);
        if(flatValue.magnitude > _maxSpeed){                                               //속도가 speed를 넘어가면
            Vector3 speedLimit = flatValue.normalized * _speed;                         //speedLimit 값을 계산하여
            _rig.velocity = new Vector3(speedLimit.x, _rig.velocity.y, speedLimit.z);   //현재 속도 변경
        }
    }

    private IEnumerator LerpMoveSpeed(){
        float time =0;
        float differnce = Mathf.Abs(_speed - _maxSpeed);
        float startVal = _maxSpeed;

        while(time < differnce){
            _maxSpeed = Mathf.Lerp(startVal, _speed, time/differnce);
            time += Time.deltaTime * 30;

            yield return null;
        }

        _maxSpeed = _speed;
        _turnMomentum = false;
    }
}
