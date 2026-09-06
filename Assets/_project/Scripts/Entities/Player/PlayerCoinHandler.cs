using System;
using UnityEngine;

public class PlayerCoinHandler : MonoBehaviour
{
    private int _coins;
    
    public int Coins => _coins;

    public event Action<int> OnGetCoins;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin) == false)
            return;
        
        int addedCoins = coin.GetCountAndDestroy();
        _coins += addedCoins;
        OnGetCoins?.Invoke(addedCoins);
    }
}
