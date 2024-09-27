using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slime : MonoBehaviour
{
    [SerializeField]
    private SlimeBase _slimeBase;

    [SerializeField]
    private SlimeList _slimeList;

    [SerializeField]
    private BonusSlime _bonusSlime;

    [SerializeField]
    private Coin _coin;

    [SerializeField]
    private int _level;

    [SerializeField]
    private BookSlimes _bookSlimes;

    public int Level { get { return _level; } }

    public int LevelMax { get { return _slimeList.SlimeBase.Count - 1; } }

    

    public void Start()
    {
        StartCoroutine(AddCoin());
    }
    public void AddClass(Coin coin, BookSlimes bookSlimes)
    {
        _coin = coin; 
        _bookSlimes = bookSlimes;
    }


    public void CheckSlimeLevel()
    {
        if (_level >= 0)
        {
            if (_slimeList.SlimeBase.Count > _level)
            {
                UpdateSlime();
            }
            else
            {
                _level = _slimeList.SlimeBase.Count - 1;
                UpdateSlime();
            }
        }
        else
        {
            _level = 0;
            UpdateSlime();
        }
    }

    public void UpdateSlime()
    {
        _slimeBase = _slimeList.SlimeBase[_level];
        GetComponent<Image>().sprite = _slimeBase.Icon;
        AddSlimeBook(_slimeBase.Id);
    }

    public void LevelStart(int level)
    {
        _level = level;
        CheckSlimeLevel();
    }

    public void LevelUp()
    {
        _level++;
        CheckSlimeLevel();
    }

    public void AddSlimeBook(int id)
    {
        _bookSlimes.UpdateBookSlime(id);
    }

    public void ClickSlime()
    {
        _coin.AddCoin(1);
    }

    private IEnumerator AddCoin()
    {
        yield return new WaitForSeconds(5f);
        double slimeGoldTime = _slimeBase.GoldTime * _bonusSlime.BonusIncome;
        
        _coin.AddCoin((int)slimeGoldTime);
        StartCoroutine(AddCoin());
    }
}