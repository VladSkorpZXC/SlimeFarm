using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [DllImport ("__Internal")]
    private static extern void AddCoinExtern(int value);

    [DllImport("__Internal")]
    private static extern void AddCristalExtern(int value);

    [SerializeField]
    private Music _music;

    [SerializeField]
    private int _coin;

    public int Coins { get { return _coin; } }

    [SerializeField]
    private int _cristal;

    public int Cristal { get { return _cristal; } }

    [SerializeField]
    private GameObject _panelExtern;

    public bool BuyCoin(int cost)
    {
        if (_coin >= cost)
        {
            _coin -= cost;
            return true;
        }

        else
        {
            print("Не хавтает Coin - " + cost);
            return false;
        }
    }

    public bool BuyCristal(int cost)
    {
        if (_cristal >= cost)
        {
            _cristal -= cost;
            return true;
        }

        else
        {
            print("Не хавтает Cristal - " + cost);
            return false;
        }
    }

    public void AddCoin(int coin)
    {
        _coin += coin;
    }

    public void AddCristal(int cristal)
    {
        _cristal += cristal;
    }

    public void Load(int coin, int cristal) 
    {
        _coin = coin;
        _cristal = cristal; 
    }

    public void ButtonAddCoinExtern()
    {
        StopMusic();
        AddCoinExtern(250);
    }

    public void ButtonAddCristalExtern()
    {
        StopMusic();
        AddCristalExtern(1);
    }

    public void StopMusic()
    {
       _music.Mute();
    }

    public void StartMusic()
    {
        _music.UnMute();
    }

    public void ShowPanelExtern()
    {
        _panelExtern.SetActive(true);
    }

    public void ClosePanelExtern()
    {
        _panelExtern.SetActive(false);
    }
}
