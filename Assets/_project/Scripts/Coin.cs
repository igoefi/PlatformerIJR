using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _count;

    public void GetCountAndDestroy(out int coins)
    {
        coins = _count;
        Destroy(gameObject);
    }
}
