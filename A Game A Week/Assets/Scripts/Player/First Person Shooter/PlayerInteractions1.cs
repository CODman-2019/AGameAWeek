using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions1 : MonoBehaviour
{
    public KeyCode      interactKey;
    private bool        interaction;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(interactKey)) { interaction = true; }
        else interaction = false;
    }

    public bool PlayerInteract() => interaction;

}
