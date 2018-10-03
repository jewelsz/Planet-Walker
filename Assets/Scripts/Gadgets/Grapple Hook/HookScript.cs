using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField]
    PlayerCollision playerCollision;
    [SerializeField]
    GravityBody gbd;

    public bool thisDestroy;
    
	// Use this for initialization
	void Start ()
    {
        thisDestroy = true;
	}
	
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Planet")
        {

            Debug.Log("hok heeft iets geraakt: " +collision.gameObject.tag);
            thisDestroy = false;
            setPosition();
            playerCollision.attractor = collision.gameObject.GetComponent<GravityAttractor>();
            gbd.attractor = collision.gameObject.GetComponent<GravityAttractor>();
            //GameObject gravity = collision.gameObject.GetComponent<GameObject>();
            //playerCollision.attractor = gravity;
        }
    }

    private void setPosition()
    {
        //transform.Translate(transform.position);
        m_Rigidbody = GetComponent<Rigidbody>();
        
        //Freeze position
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }
}
