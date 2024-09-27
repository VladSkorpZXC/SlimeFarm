using UnityEngine;
using TMPro;

public class CoinTextGame : MonoBehaviour
{
    [SerializeField]
    private Coin _coin;

    [SerializeField]
    private TMP_Text _cointText;

    [SerializeField]
    private TMP_Text _criatalText;

    public void Update()
    {
        _cointText.text = _coin.Coins.ToString();

        _criatalText.text = _coin.Cristal.ToString();
    }


}
