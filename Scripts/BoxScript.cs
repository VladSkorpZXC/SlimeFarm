using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;



public class BoxScript : MonoBehaviour
{
    [SerializeField]
    private Coin _coin;

    [SerializeField]
    private MaxSlime _maxSlime;

    [SerializeField]
    private GameObject Mob;

    [SerializeField]
    private GameObject Box;

    [SerializeField]
    private GameObject[] _spawnMob = new GameObject[3];

    [SerializeField]
    private GameObject _slime;

    [SerializeField]
    private int _levelBox;

    [SerializeField]
    private int _costBox;

    [SerializeField]
    private TMP_Text _textCostBox;

    [SerializeField]
    private int _amountBox;

    public int AmountBox { get { return _amountBox; } }

    [SerializeField]
    private BookSlimes _bookSlimes;

    public void UpdateText()
    {
        int cost = _costBox * _amountBox;
        _textCostBox.text = cost.ToString();
    }

    public void ClickBox()
    {

        int cost = _costBox * _amountBox;
        if (_maxSlime.isFull())
        {
            if (_coin.BuyCoin(cost))
            {
                int a = Random.Range(0, 3);

                GameObject spawSlime = Instantiate(_slime, Mob.transform.position, Quaternion.identity);
                spawSlime.transform.SetParent(Mob.transform, false);
                spawSlime.transform.position = _spawnMob[a].transform.position;

                spawSlime.GetComponent<Slime>().AddClass(_coin, _bookSlimes);

                spawSlime.GetComponent<Slime>().LevelStart(_levelBox);
                _amountBox++;

                UpdateText();
            }
        }
    }

    public void LevelUpBox(int levelBox)
    {
        _levelBox = levelBox;
    }


    public void Load(int amountBox)
    {
        _amountBox = amountBox;

        UpdateText();
    }
}
