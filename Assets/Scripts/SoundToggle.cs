using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    // [SerializeField] private Button _toggleButton;
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private bool _isMuted;

    void Start()
    {
        _isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        ApplyMute();
    }

    public void Toggle()
    {
        _isMuted = !_isMuted;
        PlayerPrefs.SetInt("Muted", _isMuted ? 1 : 0);
        ApplyMute();
    }

    private void ApplyMute()
    {
        AudioListener.pause = _isMuted;
        if (_icon != null)
        {
            _icon.sprite = _isMuted ? _soundOff : _soundOn;
        }
    }
}
