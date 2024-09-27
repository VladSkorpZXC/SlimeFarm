using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField]    
    private GameObject _shopPanel;

    public void OpenShopPanel()
    {
        if(_shopPanel.activeSelf == true)
        {
            _shopPanel.SetActive(false);
        }
        else
        {
            _shopPanel.SetActive(true);
        }
    }

    public void CloseShopPanel()
    {
        _shopPanel.SetActive(false);
    }
        
}
