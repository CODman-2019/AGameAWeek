using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraDrag : MonoBehaviour
{
    public GameObject character;

    public float mouseSensitivity = 100;

    private float mouseX, mouseY;
    float xrot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            character.transform.Rotate(0, -mouseX, 0);

            xrot += mouseY;

            xrot = Mathf.Clamp(xrot, -60f, 60f);
            transform.localRotation = Quaternion.Euler(xrot, 0, 0);
        }
    }
}
