using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class BookSlimes : MonoBehaviour
{
    [SerializeField]
    private SlimeList _slimeList;

    [SerializeField]
    private GameObject _panelBookSlimes;

    [SerializeField]
    private Sprite _frameUnknownSlime;

    [SerializeField]
    private Sprite _frameOpenSlime;

    [SerializeField]
    private List<int> _idOpenSlime;

    public List<int> IdOpenSlimes { get { return _idOpenSlime; } }

    [SerializeField]
    private List<Button> _buttonSlimeBook;

    public List <Button> ButtonSlimeBook { get { return _buttonSlimeBook; } }

    [SerializeField]
    private GameObject _showButtonSlime;

    [SerializeField]
    private GameObject _showSlime;


    public void OpenPanelBookSlimes()
    {
        if(_panelBookSlimes != null)
        {
            if(_panelBookSlimes.activeSelf == false)
            {
                _panelBookSlimes.SetActive(true);
            }

            else
            {
                _panelBookSlimes.SetActive(false);
            }
        }
    }

    public void Awake()
    {
        for(int i = 0; i < _buttonSlimeBook.Count; i++)
        {
            if(i < _slimeList.SlimeBase.Count)
            {
                _buttonSlimeBook[i].GetComponent<IdBookSlime>().SetSlimeButton(_slimeList.SlimeBase[i].Id, _slimeList.SlimeBase[i]);
                _buttonSlimeBook[i].transform.GetChild(0).GetComponent<Image>().sprite = _slimeList.SlimeBase[i].Icon;
            }
            else
            {
                _buttonSlimeBook[i].GetComponent<IdBookSlime>().SetSlimeButton(-1, null);
                _buttonSlimeBook[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
            }
        }
    }

    public void Load(List<int> idOpenSlimes)
    {   
        _idOpenSlime = idOpenSlimes;
        UpdatePageBookSlime();
    }

    public void UpdatePageBookSlime()
    {
        if (_idOpenSlime.Count > 0)
        {
            for (int i = 0; i < _buttonSlimeBook.Count; i++)
            {
                for (int j = 0; j < _idOpenSlime.Count; j++)
                {
                    if (_buttonSlimeBook[i].GetComponent<IdBookSlime>().IdSlime == _idOpenSlime[j])
                    {
                        _buttonSlimeBook[i].interactable = true;
                        _buttonSlimeBook[i].GetComponent<Image>().sprite = _frameOpenSlime;
                        _buttonSlimeBook[i].transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    public void OpenSlime(int id)
    {
        for(int i = 0; i < _buttonSlimeBook.Count; i++)
        {
            if(_buttonSlimeBook[i].GetComponent<IdBookSlime>().IdSlime == id)
            {
                _buttonSlimeBook[i].interactable = true;
                _buttonSlimeBook[i].GetComponent<Image>().sprite = _frameOpenSlime;
                _buttonSlimeBook[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    public void UpdateBookSlime(int id)
    {
        if(_idOpenSlime.Count > 0)
        {
            bool isListNotSlime = true;
            for(int i = 0; i < _idOpenSlime.Count; i++)
            {
                if(id == _idOpenSlime[i])
                {
                    isListNotSlime = false;
                    break;
                }        
            }

            if(isListNotSlime)
            {
                _idOpenSlime.Add(id);
                OpenSlime(id);
            } 
        }
        else
        {
            _idOpenSlime.Add(id);
            OpenSlime(id);
        }
    }

    
    public void ShowDiscriptonSlime(int i)
    {
        _showButtonSlime.SetActive(false);

        SlimeBase slimeBaseFrame = _buttonSlimeBook[i].GetComponent<IdBookSlime>().SlimeBaseID;

        _showSlime.GetComponent<ShowSlime>().OpenPanel(slimeBaseFrame);

        _showSlime.SetActive(true);
    }

    public void BackArrow()
    {
        _showSlime.SetActive(false);

        _showButtonSlime.SetActive(true);

    }

    public void Close()
    {
        _panelBookSlimes.SetActive(false);
    }
}
