using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Rotation : MonoBehaviour
{
    public float speed, xMin, xMax;
    public GameObject characterObject;

    private float xRot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xRotation = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        float yRotation = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

         xRot -= yRotation;

        xRot = Mathf.Clamp(xRot, xMin, xMax);

        characterObject.transform.Rotate(0f, xRotation , 0f);
        transform.localRotation = Quaternion.Euler(xRot , 0f, 0f);
    }
}
