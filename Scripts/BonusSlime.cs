using UnityEngine;

public class BonusSlime : MonoBehaviour
{
    [SerializeField]
    private int _levelBonusIncome;

    public double BonusIncome { get { return 1 + (_levelBonusIncome * 0.2); } }
    public void Load(int levelBonusIncome)
    {
        _levelBonusIncome = levelBonusIncome;
    }

}
