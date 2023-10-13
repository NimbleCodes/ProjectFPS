using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] Toggle _muteBGM,_muteEffect;
    [SerializeField] AudioSource _BGMPlayer;
    [SerializeField] GameObject _Cam;
    void Start()
    {
        _muteBGM.isOn = false;
        _muteEffect.isOn = false;
    }

    public void BGMVolumeChange(float value){
        _BGMPlayer.volume = value;
    }

    public void EffectVolumeChange(float value){
        EventManager.events.Invoke_EffectsVolumeChangeEvent(value);
    }

    public void VerticalMouseSenseChange(float value){
        _Cam.GetComponent<CameraFlow>().SetVertical(value);
    }

    public void HorizontalMouseSnseChage(float value){
        _Cam.GetComponent<CameraFlow>().SetHorizontal(value);
    }
}
