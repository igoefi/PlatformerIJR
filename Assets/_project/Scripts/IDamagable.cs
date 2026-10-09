using System;
using UnityEngine;

public interface IDamagable
{
    void TakeDamage(float damage);
    void TakeDamage(float damage, out float damageTaken);
}
