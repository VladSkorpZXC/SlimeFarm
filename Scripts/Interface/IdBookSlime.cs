using UnityEngine;

public class IdBookSlime : MonoBehaviour
{
    [SerializeField]
    private int _idSlime;

    [SerializeField]
    private SlimeBase _slimeBase;

    public int IdSlime { get { return _idSlime; } }

    public SlimeBase SlimeBaseID { get { return _slimeBase; } }

    public void SetSlimeButton(int id, SlimeBase slimeBase)
    {
        _idSlime = id;
        _slimeBase = slimeBase;
    }
}
