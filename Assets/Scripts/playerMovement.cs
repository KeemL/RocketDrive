using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Animations;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private ParentConstraint parent;

    // private bool boosting;

    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = GetComponent<ParentConstraint>();
        parent.constraintActive = false;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveY = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 movement = new Vector3(moveX, 0, moveY);
        rb.linearVelocity = movement;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
            BoostMode();
            //boosting = true;

        }

        if (Input.GetKeyDown(KeyCode.F))
        {

            parent.constraintActive = false;
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
}
