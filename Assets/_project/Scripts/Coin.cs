using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _count;

    public int GetCountAndDestroy()
    {
        Destroy(gameObject);
        return _count;
    }
}
