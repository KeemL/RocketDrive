using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
//using System.Numerics;

public class explosion : MonoBehaviour
{
    public float horizontalSpeed = 50.0f;

    public float verticalSpeed = 10f;
    public float tiltAngle = 30.0f;
    private Rigidbody rb;

    private bool boosting;
    [SerializeField]
    private Vector3 ogTransform;

    //private ParentConstraint parent;

    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        boosting = false;
        //parent = GetComponent<ParentConstraint>();
        audioSource = GameObject.Find("ThemeMusic").GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
            boosting = true;
            //StartCoroutine(BoostTimer());
            Boosting();
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ResetPosition();
        }

    }

    public void Boosting()
    {
        rb.AddTorque(transform.up * tiltAngle, ForceMode.Impulse);
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
        boosting = false;
    }

    // IEnumerator BoostTimer()
    // {
    //     // rb.AddForce(transform.forward * thrustSpeed, ForceMode.Force);
    //     Debug.Log("timer");
    //     yield return new WaitForSeconds(5);
    //     boosting = false;
    //     //print("Boost " + Time.time);
    // }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            ResetPosition();
            Debug.Log("resetting");
        }
    }

    void ResetPosition()
    {
        rb.linearVelocity = new Vector3(0, 0, 0);
        transform.position = ogTransform;

    }

}
