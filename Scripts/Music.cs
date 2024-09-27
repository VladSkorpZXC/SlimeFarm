using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Music : MonoBehaviour
{
    [SerializeField]
    private GameObject music;

    [SerializeField]
    private GameObject musicGear;

    [SerializeField]
    private TMP_Text musicGearText;

    [SerializeField]
    private TMP_Text musicText;

    [SerializeField]
    private Text musicTextLange;

    [SerializeField]
    private GameObject panelGear;

    [SerializeField]
    private bool _isMuteMusic;

    [SerializeField]
    private GameObject _buttonMuteMusic;

    [SerializeField]
    private Sprite _muteMusic;

    [SerializeField]
    private Sprite _unMuteMusic;

    public void Start()
    {
        musicGear.GetComponent<Slider>().value = 0.2f;
    }

    public void Update()
    {
        musicText.text = musicTextLange.text;

        music.GetComponent<AudioSource>().volume = musicGear.GetComponent<Slider>().value;
        musicGearText.text = (musicGear.GetComponent<Slider>().value * 100).ToString("0") + " %";
    }

    public void MuteMusic()
    {
        if(_isMuteMusic)
        {
            _buttonMuteMusic.GetComponent<Image>().sprite = _unMuteMusic;
            music.GetComponent<AudioSource>().mute = false;
            _isMuteMusic = false;
        }
        else
        {
            _buttonMuteMusic.GetComponent<Image>().sprite = _muteMusic;
            music.GetComponent<AudioSource>().mute = true;
            _isMuteMusic = true;
        }
    }
    public void ShowPanelGear()
    {
        if (panelGear.activeSelf == false)
        {
            panelGear.SetActive(true);
        }
        else
        {
            panelGear.SetActive(false);
        }
    }

    public void ClosePanelGear()
    {
        panelGear.SetActive(false);
    }

    public void Mute()
    {
        music.GetComponent<AudioSource>().mute = true;
    }

    public void UnMute()
    {
        if (_isMuteMusic == false)
        {
            music.GetComponent<AudioSource>().mute = false;
        }
    }
}
