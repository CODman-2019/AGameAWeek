using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game3Mouse : MonoBehaviour
{
    public Sprite       sprite_Neutral;
    public Sprite       sprite_Investigate;
    public Sprite       sprite_Travel;
    public Sprite       sprite_Talk;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        GetComponent<Image>().sprite = sprite_Neutral;
    }

    // Update is called once per frame
    void Update()
    {
        //sprite movement based on mouse position
        Vector2 mousePos = Input.mousePosition;
            //Debug.Log(mousePos);

        //anchoring mouse position to the screen ratios
        mousePos.x = Mathf.Clamp(mousePos.x, 0f, Screen.width);
        mousePos.y = Mathf.Clamp(mousePos.y, 0f, Screen.height);
        transform.position = mousePos;

        if (Input.GetMouseButton(0))
        {

        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Talk"))
        {
            Debug.Log("Talking action");
            GetComponent<Image>().sprite = sprite_Talk;
        }
        if (other.CompareTag("Inspect"))
        {
            Debug.Log("Inspection action");
            GetComponent<Image>().sprite = sprite_Investigate;
        }
        if (other.CompareTag("Travel"))
        {
            Debug.Log("Travel action");
            GetComponent<Image>().sprite = sprite_Travel;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Neutral Action");
        GetComponent<Image>().sprite = sprite_Neutral;
    }
}
