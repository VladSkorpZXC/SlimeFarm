using UnityEngine;
using TMPro;
public class MaxSlime : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textMaxSlime;

    [SerializeField]
    private GameObject _mob;

    [SerializeField]
    private int _countSlime;

    [SerializeField]
    private int _maxSlime;

    public void FixedUpdate()
    {
        _textMaxSlime.text = _mob.transform.childCount + "/" + _maxSlime;
    }

    public bool isFull()
    {
        if (_mob.transform.childCount >= _maxSlime)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
