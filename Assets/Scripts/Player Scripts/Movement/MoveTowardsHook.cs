using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsHook : MonoBehaviour
{
    [SerializeField]
    GameObject hook;
    [SerializeField]
    PlayerMovement movement;
    [SerializeField]
    GravityBody gravity;


    public bool activateMove;

    float speed;

	void Start ()
    {
        speed = 5;
        activateMove = false;

    }
	

	void Update ()
    {
        if (movement.movingDisabled && activateMove)
        {
            gravity.disableGravity();
            float step = speed * Time.deltaTime;
            Vector3 targetDir = hook.transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, step);
        }
    }

    public void moveTowardsHook()
    {
        activateMove = true;
    }

    public void setHook(GameObject hook)
    {
        this.hook = hook;
    }
}
