using System;
using UnityEngine;

public class PatrolDetector : MonoBehaviour
{
    [SerializeField] private RaycastHandler _raycastHandler;
    [SerializeField] private LayerMask _targetLayer;

    public event Action<bool> PlayerDetected;

    void Update()
    {
        Vector2 direction = transform.right;

        if (_raycastHandler.CheckRayHit(direction, _targetLayer, out _))
        {
            PlayerDetected?.Invoke(true);
        }
    }
}
