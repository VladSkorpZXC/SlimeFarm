using UnityEngine;
using System.Collections.Generic;

public class ListSlimeId : MonoBehaviour
{
    [SerializeField]
    private SlimeList _slimeList;

    [SerializeField]
    private List<int> _idSlime;

    public List<int> IdSlime { get { return _idSlime; } }

    public void Start()
    {
        CreateListIsdSlime();
    }

    public void CreateListIsdSlime()
    {
        for(int i = 0; i < _slimeList.SlimeBase.Count; i++)
        {
            _idSlime.Add(_slimeList.SlimeBase[i].Id);
        }
    }
}
