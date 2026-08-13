using System;
using UnityEngine;

public class PlayerCoinHandler : MonoBehaviour
{
    public event Action<int> OnGetCoins;
    
    private int _coins;
    
    public int Coins => _coins;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin) == false)
            return;
        
        int addedCoins = coin.GetCountAndDestroy();
        _coins += addedCoins;
        OnGetCoins?.Invoke(addedCoins);
    }
}
