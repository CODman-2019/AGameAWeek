using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Movement : MonoBehaviour
{
    public float vertical_Speed;
    public float horizontal_Speed;

    public KeyCode _UpKey, _altUpKey;
    public KeyCode _DownKey, _altDownKey;

    public KeyCode _LeftKey, _altLeftKey;
    public KeyCode _RightKey, _altRightKey;

    float speed_Multiplier = 1;
    public float speed_Sprint;
    public KeyCode _Sprint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Speed();

        if (Input.GetKey(_UpKey) || Input.GetKey(_altUpKey))
        {
            transform.Translate(0, 0, vertical_Speed * speed_Multiplier * Time.deltaTime);
        }
        else if (Input.GetKey(_DownKey) || Input.GetKey(_altDownKey))
        {
            transform.Translate(0, 0, -vertical_Speed * speed_Multiplier * Time.deltaTime);
        }

        if (Input.GetKey(_RightKey) || Input.GetKey(_altRightKey))
        {
            transform.Translate(horizontal_Speed * speed_Multiplier * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(_LeftKey) || Input.GetKey(_altLeftKey))
        {
            transform.Translate(-horizontal_Speed * speed_Multiplier * Time.deltaTime, 0, 0);
        }
    }

    void Speed()
    {
        if (Input.GetKey(_Sprint))
        {
            speed_Multiplier = speed_Sprint;
        }
        else
        {
            speed_Multiplier = 1;
        }
    }
}
