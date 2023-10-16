using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] Toggle _muteBGM,_muteEffect;
    [SerializeField] AudioSource _BGMPlayer;
    [SerializeField] AudioSource[] _Effects = null;
    [SerializeField] GameObject _Cam;
    void Start()
    {
        _muteBGM.isOn = false;
        _muteEffect.isOn = false;
    }

    public void BGMVolumeChange(float value){
        _BGMPlayer.volume = value;
    }

    public void MuteBGM(bool val){
        _BGMPlayer.mute = val;
    }

    public void MuteEffect(bool val){
        if(_Effects == null){
            GameObject[] allEffects = GameObject.FindGameObjectsWithTag("SoundEffect");
            for(int i =0; i < allEffects.Length; i++){
                _Effects[i] = allEffects[i].GetComponent<AudioSource>();
            }
        }
        for(int i =0; i < _Effects.Length; i++){
            _Effects[i].mute = val;
        }
    }

    public void EffectVolumeChange(float value){
        if(_Effects == null){
            GameObject[] allEffects = GameObject.FindGameObjectsWithTag("SoundEffect");
            for(int i =0; i < allEffects.Length; i++){
                _Effects[i] = allEffects[i].GetComponent<AudioSource>();
            }
        }
        for(int i =0; i < _Effects.Length; i++){
            _Effects[i].volume = value;
        }
    }
    public void SetEffects(AudioSource[] effect){
        _Effects = effect;
    }
    public void VerticalMouseSenseChange(float value){
        _Cam.GetComponent<CameraFlow>().SetVertical(value);
    }

    public void HorizontalMouseSnseChage(float value){
        _Cam.GetComponent<CameraFlow>().SetHorizontal(value);
    }

    public void OnOkClick(){
        gameObject.SetActive(false);
    }
}
