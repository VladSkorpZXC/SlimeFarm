using UnityEngine;

public class SlimeCoupe : MonoBehaviour
{
    public bool _detected;
    public GameObject _gameObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slime" && gameObject.GetComponent<BoxCollider2D>().isTrigger)
        {
            int SlimeLevelOther = other.gameObject.GetComponent<Slime>().Level;
            int SlimeLevel = gameObject.GetComponent<Slime>().Level;

            if (SlimeLevelOther == SlimeLevel)
            {
                if (SlimeLevel < gameObject.GetComponent<Slime>().LevelMax)
                {
                    _gameObject = other.gameObject;
                    _detected = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _detected = false;
        _gameObject = null;
    }

    private void OnMouseUp()
    {
        if (_detected)
        {
            gameObject.GetComponent<Slime>().LevelUp();
            Destroy(_gameObject);
        }
    }
}
