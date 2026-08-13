using System;
using UnityEngine;

[RequireComponent(typeof(TargetMovement))]
public class FollowPlayerHandler : MonoBehaviour
{
    private TargetMovement _targetMovement;

    private void Start() =>
        _targetMovement = GetComponent<TargetMovement>();

    public void FollowPlayer(Transform player) =>
        _targetMovement.SetTarget(player);
}
