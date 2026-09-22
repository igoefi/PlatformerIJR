using System;
using UnityEngine;

[RequireComponent(typeof(StatsHandler))]
public abstract class Enemy : MonoBehaviour
{
    public StatsHandler StatsHandler { get; protected set; }
}
