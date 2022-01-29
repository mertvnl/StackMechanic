using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StackableCube : MonoBehaviour, IStackable
{
    private const float SCALE_MULTIPLIER = 0.5f;
    private const float SCALE_DURATION = 0.5f;
    private const float JUMP_RADIUS = 1f;

    private Collider collider;
    public Collider Collider { get { return collider == null ? collider = GetComponentInChildren<Collider>() : collider; } }

    private Tween scaleTween;

    public void OnStacked()
    {
        if (scaleTween != null)
            scaleTween.Kill(true);

        scaleTween = transform.DOPunchScale(Vector3.one * SCALE_MULTIPLIER, SCALE_DURATION, 2);
    }

    public void OnUnstacked()
    {
        Collider.enabled = false;
        transform.SetParent(null);

        Vector3 jumpPosition = transform.position + Random.insideUnitSphere * JUMP_RADIUS;
        jumpPosition.y = 0;
        transform.DOJump(jumpPosition, 1f, 1, 0.5f).OnComplete(()=> Collider.enabled = true);
    }
}
