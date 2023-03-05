using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody),typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joy;
    private Vector3 moveInput;
    public float speed = 2f;
    private float rayGroundDist = 1;
    private RaycastHit slopeHit;
    private float distToGround = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {       
        moveInput = new Vector3(joy.Horizontal, 0, joy.Vertical);
        //this.gameObject.transform.rotation= Quaternion.Euler(joy.Horizontal, 0, joy.Vertical);
        Move(moveInput, rb, speed);
    }
    public static void Move(Vector3 moveInput, Rigidbody rigidbody, float speed)
    {
        Vector3 vel = rigidbody.velocity;
        //Quaternion deltaRotation = Quaternion.Euler(moveInput * Time.fixedDeltaTime);
        //rigidbody.MoveRotation(Quaternion.LookRotation(vel));
        rigidbody.MovePosition(rigidbody.position + moveInput * speed * Time.fixedDeltaTime);
    }
    public bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position, Vector3.down, distToGround);

    }
}
