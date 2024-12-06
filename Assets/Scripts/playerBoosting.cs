using UnityEngine;
using UnityEngine.Animations;

public class Boosting : MonoBehaviour
{
    private Rigidbody rb;
    private ParentConstraint parent;

    private ParentConstraint rocket;

    public float thrustSpeed = 30f;
    private bool inRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parent = GetComponent<ParentConstraint>();
        parent.constraintActive = false;

        rocket = GetComponent<ParentConstraint>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            // rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
            // BoostMode();
            //boosting = true;

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("pressed F");
            rb.AddForce(transform.forward * thrustSpeed, ForceMode.Impulse); //blue axis

            parent.constraintActive = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            rocket.constraintActive = true;

        }
    }
    void BoostMode()
    {
        // anim.SetBool("boosting", true);
        rb.linearVelocity = new Vector3(0, 0, 0);
        parent.constraintActive = true;
        Debug.Log("Moving with rocket");
        //anim.SetBool("boosting", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rocket"))
        {
            Debug.Log("in range");
            inRange = true;
        }
    }
}
