using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody),typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joy;
    public Player player;
    private Vector3 moveInput;
    public float speed = 2f;
    //private float rayGroundDist = 1;
    //private RaycastHit slopeHit;
    private RaycastHit checkStairHit;
    private float distToGround = 1f;
    //private bool buildable = true;
    public Vector3 rayOffset;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        //Ray ray = new Ray(transform.position + rayOffset, Vector3.down);
    }

    // Update is called once per frame
    void Update()
    {       
        moveInput = new Vector3(joy.Horizontal, 0, joy.Vertical);
        //this.gameObject.transform.rotation= Quaternion.Euler(joy.Horizontal, 0, joy.Vertical);
        Debug.DrawRay(transform.position *2, Vector3.down);
        Move(moveInput, rb, speed);
        //check();
    }
    public void Move(Vector3 moveInput, Rigidbody rigidbody, float speed)
    {
        Vector3 vel = rigidbody.velocity;
        
        Quaternion rotation =Quaternion.LookRotation(new Vector3(joy.Horizontal, 0f, joy.Vertical));
        rigidbody.transform.rotation = rotation;
        //do raycast
        if (check(moveInput,rigidbody) )
        {
            rigidbody.MovePosition(rigidbody.position + moveInput * speed * Time.fixedDeltaTime);
        }
        
    }
    public bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position, Vector3.down, distToGround);

    }
    bool check(Vector3 moveInput, Rigidbody rigidbody)
    {
       // Vector3 rayPos = new Vector3(joy.Horizontal +transform.position.x, 0, joy.Vertical + transform.position.y) * 2;
        if (Physics.Raycast(rigidbody.position + moveInput * 1, Vector3.down, out checkStairHit, 8.0f))
        {
            
            if (checkStairHit.transform.gameObject.CompareTag("Stair"))
            {
                Stair stair = checkStairHit.transform.gameObject.GetComponent<Stair>();
                if (stair.currentColor != transform.gameObject.GetComponent<Player>().currentColor && transform.gameObject.GetComponent<PlayerBrickController>().stack <=0 )
                {
                    
                    return false;
                }
                
            }
            
            return true;

        }
        Debug.Log("true");
        return true;
    }
}
