using UnityEngine;

public class BulletCatcher : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        Destroy(collision.gameObject);   
    }
}
