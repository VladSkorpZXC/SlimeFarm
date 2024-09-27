using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private Coin _coin;

    [SerializeField]
    private BoxScript _boxScript;

    [SerializeField]
    private language _language;


    [SerializeField]
    private BonusSlime _bonusSlime;

    [SerializeField]
    private TMP_Text _textBonusSlime;

    [SerializeField]
    private GameObject _buttonUpgardeSlimeIncome;

    [SerializeField]
    private GameObject _buttonUpgardeBox;

    [SerializeField]
    private TMP_Text _textCostUpgradeSlimeIncome;

    [SerializeField]
    private TMP_Text _textCostUpgradeBox;

    [SerializeField]
    private TMP_Text _textLevelSlimeIncome;

    [SerializeField]
    private TMP_Text _textLevelBox;

    [SerializeField]
    private int _levelSlimeIncome;

    [SerializeField]
    private int _levelBox;

    public int LevelSlimeIncome {  get { return _levelSlimeIncome; } }

    public int LevelBox {  get { return _levelBox; } }

    [SerializeField]
    public int _costUpgradeSlimeIncome;

    [SerializeField]
    private int _costUpgradeBox;

    [SerializeField]
    private Text _textLevelLanguage;

    [SerializeField]
    private Text _textMaxLanguage;


    [SerializeField]
    private Image _marketSprite;

    [SerializeField]
    private List<Sprite> _marketSpriteLanguage;

    private void Start()
    {
        CostUpgrade();
        UpdateTextShop();


        if (_language.CurrentLanguage == "ru")
        {
            _marketSprite.sprite = _marketSpriteLanguage[0];
        }
        else if (_language.CurrentLanguage == "en")
        {
            _marketSprite.sprite = _marketSpriteLanguage[1];
        }
        else if (_language.CurrentLanguage == "tr")
        {
            _marketSprite.sprite = _marketSpriteLanguage[2];
        }

    }

    public void UpdateTextShop()
    {
        if (_levelSlimeIncome < 10)
        {
            _textLevelSlimeIncome.text = _textLevelLanguage.text + " - " + (_levelSlimeIncome + 1).ToString();
        }
        else
        {
            _textLevelSlimeIncome.text = _textLevelLanguage.text + " - " + _textMaxLanguage;
            _buttonUpgardeSlimeIncome.SetActive(false);
        }
        if (_levelBox < 5)
        {
            _textLevelBox.text = _textLevelLanguage.text + " - " + (_levelBox + 1).ToString();
        }
        else
        {
            _textLevelBox.text = _textLevelLanguage.text + " - " + _textMaxLanguage;
            _buttonUpgardeBox.SetActive(false);
        }

        _textBonusSlime.text = "X " + _bonusSlime.BonusIncome.ToString();

        _textCostUpgradeSlimeIncome.text = _costUpgradeSlimeIncome.ToString();
        _textCostUpgradeBox.text = _costUpgradeBox.ToString();
    }

    public void Load(int levelSlimeIncome, int levelBox)
    {
        _levelSlimeIncome = levelSlimeIncome;
        _levelBox = levelBox;

        _boxScript.LevelUpBox(levelBox);
        _bonusSlime.Load(levelSlimeIncome);

        CostUpgrade();

        UpdateTextShop();
    }

    public void CostUpgrade()
    {
        _costUpgradeSlimeIncome = (_levelSlimeIncome + 1) * 5;
        _costUpgradeBox = (_levelBox + 1) * 10;
    }

    public void BuyUpgradeBox()
    {
        if(_coin.Cristal >= _costUpgradeBox)
        {
            if (_levelBox < 5)
            {
                _coin.AddCristal(-_costUpgradeBox);
                _levelBox++;

                _boxScript.LevelUpBox(_levelBox);

                CostUpgrade();

                if (_levelBox == 5)
                {
                    _buttonUpgardeBox.SetActive(false);
                }
            }
            UpdateTextShop();
        }
        else
        {
            Debug.Log("Нет кристалов");
        }
    }

    public void BuyUpgradeSlimeIncome()
    {
        if (_coin.Cristal >= _costUpgradeSlimeIncome)
        {
            if (_levelSlimeIncome < 10)
            {
                _coin.AddCristal(-_costUpgradeSlimeIncome);
                _levelSlimeIncome++;

                _bonusSlime.Load(_levelSlimeIncome);

                CostUpgrade();

                if (_levelSlimeIncome == 10)
                {
                    _buttonUpgardeSlimeIncome.SetActive(false);
                }
            }
            UpdateTextShop();
        }
        else
        {
            Debug.Log("Нет кристалов");
        }
    }
}
