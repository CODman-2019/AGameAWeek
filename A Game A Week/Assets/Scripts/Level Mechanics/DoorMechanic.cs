using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorMechanic : MonoBehaviour
{
    public Text                     propmt;
    public float                    openAmount;
    public float                    lerpTime;
    public float                    timer;
    //public GameObject               doorLeft, doorRight;

    private bool                    opened;
    private PlayerInteractions1     playerInput;
    private float                   doorThreshold;
    private Vector3                 resetPos, newPos;


    // Start is called before the first frame update
    void Start()
    {
        doorThreshold = 0f;
        resetPos = gameObject.transform.rotation.eulerAngles;
        newPos = resetPos;
        newPos.y += openAmount; 
        playerInput = null;
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.PlayerInteract())
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        yield return null;
        
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newPos), timer);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInput = other.GetComponent<PlayerInteractions1>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInput = null;
    }

}
