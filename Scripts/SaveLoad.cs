using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class SaveLoad : MonoBehaviour
{
    private const string saveSlime = "slimeKey";
    private const string saveCount = "coinKey";
    private const string saveBook = "bookKey";
    private const string saveShop = "shopKey";

    // Переменные для сохранения 

    [SerializeField]
    private int _coin;

    [SerializeField]
    private int _cristal;

    [SerializeField]
    private int _amountBox;

    public int AmountBox { get { return _amountBox; } }

    [SerializeField]
    private List<int> _idBookSlimes;

    [SerializeField]
    private List<int> _idNewSlimesCristal;

    [SerializeField]
    private List<float> _positionX;

    public List<float> PositionX { get { return _positionX; } }

    [SerializeField]
    private List<float> _positionY;

    public List<float> PositionY { get { return _positionY; } }

    [SerializeField]
    private List<int> _level;
  
    public List<int> Level { get { return _level; } }

    [SerializeField]
    private int _levelUpgradeBox;

    [SerializeField]
    private int _levelUpgradeSlimeIncome;

    // Откуда берем двнные для сохранения 

    [SerializeField]
    private Coin _gameCoion;

    [SerializeField]
    private BoxScript _gameAmountBox;

    [SerializeField]
    private BookSlimes _bookSlimes;

    [SerializeField]
    private ShowSlime _showSlimes;

    [SerializeField]
    private Shop _shop;

    [SerializeField]
    private GameObject _gameAllSlime;

    [SerializeField]
    private GameObject _slimePrefab;

    private void Start()
    {
        LoadGame();
        StartCoroutine(SaveTime());
    }

    private IEnumerator SaveTime()
    {
        yield return new WaitForSeconds(3f);
        SaveGame();
        StartCoroutine(SaveTime());
    }

    public void SaveGame()
    {
        SaveGameCoin();
        SaveGameBox();
        SeveSlime();

        SaveGameBookSlimes();

        SaveShop();

        Save();
    }

    public void LoadGame() 
    {
        LoadGameCoin();

        LoadGameBookSlimes();

        LoadGameSlime();

        LoadGameShop();
    }


    // Сохраненя даных 

    public void SaveGameCoin()
    {
        _coin = _gameCoion.Coins;
        _cristal = _gameCoion.Cristal;
    }

    public void SaveGameBox()  
    {
        _amountBox = _gameAmountBox.AmountBox;
    }

    public void SaveGameBookSlimes()  
    {
        _idBookSlimes = _bookSlimes.IdOpenSlimes;
        _idNewSlimesCristal = _showSlimes.IdNewSlimeCristal;
    }

    public void SaveShop()
    {
        _levelUpgradeBox = _shop.LevelBox;
        _levelUpgradeSlimeIncome = _shop.LevelSlimeIncome;
    }

    public void SeveSlime()
    {
        ClearListSaveSlime();

        for(int i = 0; i < _gameAllSlime.transform.childCount; i++)
        {
            GameObject slimeSave = _gameAllSlime.transform.GetChild(i).gameObject;

            _positionX.Add(slimeSave.transform.position.x);
            _positionY.Add(slimeSave.transform.position.y);
            _level.Add(slimeSave.GetComponent<Slime>().Level);
        }
    }

    public void ClearListSaveSlime()
    {
        _positionX.Clear();
        _positionY.Clear();
        _level.Clear();
    }

    // Загурзка даных 

    public void LoadGameCoin()
    {
        var data = SaveSlimeManager.Load<SaveDate.SaveCountData>(saveCount);

        _gameCoion.Load(data.CoinCount, data.CristalCount);
        _gameAmountBox.Load(data.AmountBox);

    }

    public void LoadGameBookSlimes()
    {
        var data = SaveSlimeManager.Load<SaveDate.SaveBookSlimesData>(saveBook);

        if(data.IdBookSlimes != null && data.IdBookSlimes.Count > 0)
        {
            _bookSlimes.Load(data.IdBookSlimes);
            _showSlimes.Load(data.IdNewSlimesCristal);
        }

    }

    public void LoadGameShop()
    {
        var data = SaveSlimeManager.Load<SaveDate.SaveShopData>(saveShop);

        _shop.Load(data.LevelUpgradeSlimeIncome, data.LevelUpgardeBox);
    }

    public void LoadGameSlime()
    {
        var data = SaveSlimeManager.Load<SaveDate.SaveSlimeData>(saveSlime);

        LoadSlime(data.X, data.Y, data.Level);
    }

    public void LoadSlime(List<float> X, List<float> Y, List<int> Level)
    {
        for(int i = 0; i < Level.Count; i++)
        {
            GameObject spawSlime = Instantiate(_slimePrefab, _gameAllSlime.transform.position, Quaternion.identity);
            spawSlime.transform.SetParent(_gameAllSlime.transform, false);
            spawSlime.transform.position = new Vector2(X[i], Y[i]);

            spawSlime.GetComponent<Slime>().AddClass(_gameCoion, _bookSlimes);

            spawSlime.GetComponent<Slime>().LevelStart(Level[i]);
        }
    }


    // Сохранение в PlayerPrefs

    public void Save()
    {
        SaveSlimeManager.Save(saveSlime, GetSaveSlimeSnapshot());
        SaveSlimeManager.Save(saveCount, GetSaveCountSnapshot());
        SaveSlimeManager.Save(saveBook, GetSaveBookSlimeSnapshot());
        SaveSlimeManager.Save(saveShop, GetSaveShopSnapshot());
    }

    private SaveDate.SaveSlimeData GetSaveSlimeSnapshot()
    {
        var data = new SaveDate.SaveSlimeData()
        {
            X = _positionX,
            Y = _positionY,
            Level = _level
        };

        return data;
    }


    private SaveDate.SaveCountData GetSaveCountSnapshot()
    {
        var data = new SaveDate.SaveCountData()
        {
            CoinCount = _coin,
            CristalCount = _cristal,
            AmountBox = _amountBox
        };

        return data;
    }

    private SaveDate.SaveBookSlimesData GetSaveBookSlimeSnapshot()
    {
        var data = new SaveDate.SaveBookSlimesData()
        {
            IdBookSlimes = _idBookSlimes,
            IdNewSlimesCristal = _idNewSlimesCristal
        };

        return data;
    }


    private SaveDate.SaveShopData GetSaveShopSnapshot()
    {
        var data = new SaveDate.SaveShopData()
        {
            LevelUpgardeBox = _levelUpgradeBox,
            LevelUpgradeSlimeIncome = _levelUpgradeSlimeIncome
        };

        return data;
    }

}
