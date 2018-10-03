using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    MoveTowardsHook moveTowardsHook;
    [SerializeField]
    PlayerMovement playermovement;
    [SerializeField]
    HookShootScript hookShoot;
    [SerializeField]
    GravityBody gravity;

    public GravityAttractor attractor;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grapple Hook"))
        {
            moveTowardsHook.activateMove = false;
            playermovement.movingDisabled = false;
            hookShoot.destroyBullet();
            gravity.enableGravity(attractor);
        }
    }
}
