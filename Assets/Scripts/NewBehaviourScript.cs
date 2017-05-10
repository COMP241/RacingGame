using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public float acceleration;
    public float steering;
    private Rigidbody2D rb;
    public float driftForce;
    // Use this for initialization
    void Start()
    {
    rb = GetComponent<Rigidbody2D>();   		
	}

// Update is called once per frame
void FixedUpdate()
{
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    Vector2 speed = transform.up * (vertical * acceleration);
    rb.AddForce(speed);
    
    float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
    if (direction <= 0.0f)
    {
        rb.rotation += horizontal * steering * (rb.velocity.magnitude / 5.0f);
    }
    else
    {
        rb.rotation -= horizontal * steering * (rb.velocity.magnitude / 5.0f);
    }
    
    Vector2 forward = new Vector2(0.0f, 0.5f);
    float steeringRightAngle;
    if (rb.angularVelocity > 0)
    {
        steeringRightAngle = 90;
    }
    else
    {
        steeringRightAngle = -90;
    }

    Vector2 rightAngleFromForward = Quaternion.AngleAxis(steeringRightAngle, Vector3.forward) * forward;
    Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(rightAngleFromForward), Color.green);

    driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(rightAngleFromForward.normalized));
    Vector2 relativeForce = (rightAngleFromForward.normalized * -1.0f) * (driftForce * 10.0f);

    Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(relativeForce), Color.red);
    rb.AddForce(rb.GetRelativeVector(relativeForce));

    if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(rightAngleFromForward.normalized*(driftForce * 4.0f));
        }

    
}
}
