using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float _healCount;

    public float GetAndDestroy()
    {
        Destroy(gameObject);
        return _healCount;
    }
}
