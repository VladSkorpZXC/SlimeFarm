using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "New Slime", menuName = "Scriptable Object/SlimeBase")]
public class SlimeBase : ScriptableObject
{
    [SerializeField]
    private int _id;

    [SerializeField]
    private string _name;

    [SerializeField]
    private string _level;

    [SerializeField]
    private Sprite _icon;

    [SerializeField]
    private int _goldCost;

    [SerializeField]
    private int _goldTime;

    public int Id { get { return _id; } }

    public string Name { get { return _name; } }

    public string Level { get { return _level;  } }

    public Sprite Icon { get { return _icon; } }

    public int GoldCost { get { return _goldCost; } }

    public int GoldTime { get { return _goldTime; } }
}
