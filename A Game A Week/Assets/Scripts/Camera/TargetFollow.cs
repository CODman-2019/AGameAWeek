using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    public GameObject target;
    public bool followX, followY, followZ;

    private Vector3 offset = new Vector3();

    private void Start()
    {
        offset = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (followX) offset.x = target.transform.position.x;
            if (followY) offset.y = target.transform.position.y;
            if (followZ) offset.z = target.transform.position.z;

            transform.position = offset;
        }

    }
}
