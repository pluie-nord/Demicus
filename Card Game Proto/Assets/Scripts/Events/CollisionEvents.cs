using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvents : MonoBehaviour
{
    public delegate void CollisionEventHandler(ICollision collision);
    public static event CollisionEventHandler OnCollision;

    public static void Collided(ICollision collision)
    {
        OnCollision?.Invoke(collision);
    }
}
