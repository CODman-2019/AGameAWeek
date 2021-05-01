using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2D_Jump : MonoBehaviour
{
    public float jumpForce;
    public float groundRange;

    public Transform groundCheck;
    public LayerMask ground_Mask;

    public KeyCode jump;
    public KeyCode jumpAlt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jump) || Input.GetKeyDown(jumpAlt))
        {
            if (Physics.CheckSphere(groundCheck.position, groundRange, ground_Mask)) 
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}
