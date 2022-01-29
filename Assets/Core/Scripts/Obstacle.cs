using CustomEventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IStackable stackable = other.GetComponent<IStackable>();

        if (stackable != null)
        {
            Events.OnObstacleCollision.Invoke(stackable);
        }
    }
}
