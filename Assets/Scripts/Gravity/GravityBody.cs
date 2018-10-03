using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;

    private Transform myTransform;
    public Rigidbody rb;
    MoveTowardsHook moveTowardshook;

    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        myTransform = transform;
    }

    void Update()
    {
        attractor.Attract(myTransform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            Debug.Log("touched planet");
            attractor = collision.gameObject.GetComponent<GravityAttractor>();
        }
    }

    public void disableGravity()
    {
        attractor.disabled = true;
    }

    public void enableGravity(GravityAttractor attractorObj)
    {
        Debug.Log("gravityBody script object inhoud: " + attractor.gameObject.tag);
        attractor.disabled = false;
    }
}
