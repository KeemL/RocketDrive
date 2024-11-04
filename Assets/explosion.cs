using UnityEngine;
using System.Collections;
//using System.Numerics;

public class explosion : MonoBehaviour
{
    public float thrust = 50.0f;
    private Rigidbody rb;
    private IEnumerator coroutine;

    private bool boosting = false;
    private Vector3 ogTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        ogTransform = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
            Boosting();

            //Debug.Log("pressed E key");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * thrust, ForceMode.Force);
            //  Boosting();

            Debug.Log("pressed Space key");
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            ResetPosition();

        }
    }

    void ResetPosition()
    {
        rb.linearVelocity = new Vector3(0, 0, 0);
        transform.position = ogTransform;

    }

    public void Boosting()
    {
        rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        // boosting = true;
        // if (boosting)
        // {
        //     StartCoroutine(BoostTimer(3f));
        // }
        // boosting = false;
    }

    private IEnumerator BoostTimer(float time)
    {

        while (boosting)
        {
            rb.AddForce(transform.forward * thrust, ForceMode.Force);
            yield return null;
            //yield return new WaitForSeconds(3);
            //print("Boost " + Time.time);

        }
    }
}
