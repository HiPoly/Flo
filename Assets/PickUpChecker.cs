using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpChecker : MonoBehaviour
{

    public bool enablesPlatformControl = false;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("Item picked up");
            collider.GetComponentInParent<PlayerState>().ActivateCanMovePlatform();
            Destroy(gameObject);
            
        }
    }
}
