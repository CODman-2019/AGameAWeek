using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2D : MonoBehaviour
{
    public float speed;

    public KeyCode right;
    public KeyCode rightAlt;
    public KeyCode left;
    public KeyCode leftAlt;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(right) || Input.GetKey(rightAlt))
            transform.Translate(speed * Time.deltaTime, 0, 0);

        if(Input.GetKey(left)|| Input.GetKey(leftAlt))
            transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    public void BounceForce(Vector3 force)
    {
        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }
}
