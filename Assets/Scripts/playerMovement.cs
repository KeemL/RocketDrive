using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Animations;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 100f;
    private Rigidbody rb;

    public float thrust = 5f;

    public float smoothingFactor = 10f;

    public float jumpHeight = 50f;


    // private bool boosting;

    private Animator anim;

    public Vector3 movement;

    float gravityMultiplier = -20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            moveSpeed = 15f;

        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveY = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 movement = new Vector3(moveX, 0, moveY);
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y + gravityMultiplier * Time.deltaTime, movement.z); //for gravity

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
            transform.forward = Vector3.Lerp(movement, new Vector3(movement.x, 0, movement.z), smoothingFactor * Time.deltaTime); //rotation turning around and stuff
        }



    }



}
