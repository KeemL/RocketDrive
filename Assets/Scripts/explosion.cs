using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
//using System.Numerics;

public class explosion : MonoBehaviour
{
    public float horizontalSpeed = 50.0f;

    public float verticalSpeed = 10f;
    private Rigidbody rb;
    private IEnumerator coroutine;

    private bool boosting;
    private Vector3 ogTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        boosting = false;
        ogTransform = transform.position;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         // rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
    //         Boosting();

    //         //Debug.Log("pressed E key");
    //     }

    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         rb.AddForce(transform.forward * thrustSpeed, ForceMode.Force);
    //         //  Boosting();

    //         Debug.Log("pressed Space key");
    //     }

    // }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
            boosting = true;
            //StartCoroutine(BoostTimer());
            Boosting();
            Debug.Log("pressed E key");
        }


    }

    public void Boosting()
    {
        Debug.Log("boosting");
        rb.AddForce(transform.forward * horizontalSpeed, ForceMode.Impulse); //blue axis
        rb.AddForce(transform.up * verticalSpeed, ForceMode.Impulse); //green axis
        // rb.AddForce(transform.forward * thrustSpeed, ForceMode.Impulse);
        // PlayerInput.DeactivateInput
        // Debug.DrawLine(transform.forward, transform.forward * thrust);
        // boosting = true;
        // if (boosting)
        // {
        //     StartCoroutine(BoostTimer(3f));
        // }
        // boosting = false;
    }

    IEnumerator BoostTimer()
    {
        // rb.AddForce(transform.forward * thrustSpeed, ForceMode.Force);
        Debug.Log("timer");
        yield return new WaitForSeconds(5);
        boosting = false;
        //print("Boost " + Time.time);
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            //ResetPosition();
            Debug.Log("resetting");
        }
    }

    void ResetPosition()
    {
        rb.linearVelocity = new Vector3(0, 0, 0);
        transform.position = ogTransform;

    }

}
