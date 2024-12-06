using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Animations;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f;
    private Rigidbody rb;


    public float thrust = 5f;

    public float smoothingFactor = 10f;

    public float jumpHeight = 5f;


    // private bool boosting;

    private Animator anim;

    public ParentConstraint rocket;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveY = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 movement = new Vector3(moveX, 0, moveY);
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // Debug.Log("movement:");
        // Debug.Log(movement);
        // Debug.Log("linear velocity:");
        // Debug.Log(rb.linearVelocity);

        if (moveX != 0)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveX));
        }
        else if (moveY != 0)
        {
            anim.SetFloat("Speed", 5);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

        if (movement != new Vector3(0, 0, 0))
        {
            transform.forward = Vector3.Lerp(movement, new Vector3(movement.x, 0, movement.z), smoothingFactor * Time.deltaTime);
        }




        if (Input.GetKeyDown(KeyCode.Q))
        {
            rocket.constraintActive = true;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

        }
    }

}
