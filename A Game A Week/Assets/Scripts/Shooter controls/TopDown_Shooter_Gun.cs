using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown_Shooter_Gun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float mouseX = Input.mousePosition.x;
        //float mouseY = Input.mousePosition.y;
        //float mouseZ = Input.mousePosition.z;
        //Debug.Log(mouseX + " " + mouseY + " " +mouseZ);

        float xLook = Input.mousePosition.x - transform.position.x;
        float yLook = Input.mousePosition.y - transform.position.z;

        Vector3 look = new Vector3(xLook, 0f, yLook);
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 Lookdir = Input.mousePosition - transform.position;
        
        float angle = Mathf.Atan2(Lookdir.x, Lookdir.z) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, angle, 0);
        //transform.LookAt(look);
    }
}




        ////
        //

        ////
        //
        ////this.GetComponent<Rigidbody>().rotation;