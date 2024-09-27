using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Settings;
using System.Collections.Generic;
public class ShowSlime : MonoBehaviour
{
    [SerializeField]
    private SlimeBase _slimeBase;

    [SerializeField]
    private BookSlimes _bookSlimes;

    [SerializeField]
    private Image _slimeImage;

    [SerializeField]
    private TMP_Text _goldTimeText;

    [SerializeField]
    private TMP_Text _IncomeText;

    [SerializeField]
    private int _isOpenSlime;

    [SerializeField]
    private GameObject _buttonNextSlime;

    [SerializeField]
    private GameObject _buttonBackSlime;

    [SerializeField]
    private Text _IncomeTextLang;

    [SerializeField]
    private List<int> _idNewSlimeCristal;

    public List<int> IdNewSlimeCristal {  get { return _idNewSlimeCristal; } }

    [SerializeField]
    private TMP_Text _getCristal;

    [SerializeField]
    private Text _getCristalLanguage;

    [SerializeField]
    private Button _buttonCristalNewSlime;

    public void OpenPanel(SlimeBase slimeBase)
    {
        _slimeBase = slimeBase;

        _slimeImage.sprite = _slimeBase.Icon;

        _goldTimeText.text = _slimeBase.GoldTime.ToString();

        _IncomeText.text = _IncomeTextLang.text;

        _getCristal.text = _getCristalLanguage.text;

        for (int i = 0; i < _bookSlimes.IdOpenSlimes.Count; i++)
        {
            if (_slimeBase.Id == _bookSlimes.IdOpenSlimes[i])
            {
                _isOpenSlime = i;
            }
        }


        bool isNewSlimeCristal = true;

        for (int i = 0; i < _idNewSlimeCristal.Count; i++)
        {
            if (_idNewSlimeCristal[i] == _slimeBase.Id)
            {
                _buttonCristalNewSlime.interactable = false;
                isNewSlimeCristal = false;
                break;
            }
        }

        if(isNewSlimeCristal)
        {
            _buttonCristalNewSlime.interactable = true;
        }

        CheakNextSlime();
    }

    public void CheakNextSlime()
    {
        if (_bookSlimes.IdOpenSlimes.Count > 0)
        {
            if (_bookSlimes.IdOpenSlimes.Count > 1)
            {
                if (_isOpenSlime == _bookSlimes.IdOpenSlimes.Count - 1)
                {
                    _buttonNextSlime.SetActive(false);
                }
                else
                {
                    _buttonNextSlime.SetActive(true);
                }

                if (_isOpenSlime == 0)
                {
                    _buttonBackSlime.SetActive(false);
                }
                else
                {
                    _buttonBackSlime.SetActive(true);
                }

            }
            else
            {
                _buttonNextSlime.SetActive(false);
                _buttonBackSlime.SetActive(false);
            }
        }
        else
        {
            _buttonNextSlime.SetActive(false);
            _buttonBackSlime.SetActive(false);
        }
    }

    public void NextSlime(int i)
    {
        _bookSlimes.ShowDiscriptonSlime(_bookSlimes.IdOpenSlimes[_isOpenSlime + i]); // ѕо пор€дку List слизней (перебрать массив открытых слизней сделать его по паор€дку)
    }

    public void ButtonOpenSlime()
    {
        _idNewSlimeCristal.Add(_slimeBase.Id);
        _buttonCristalNewSlime.interactable = false;
    }

    public void RU(int i)
    {
        if(i == 0)
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];

        else
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
    }

    public void Load(List<int> idNewSlimeCristal)
    {
        _idNewSlimeCristal = idNewSlimeCristal;
    }
}
