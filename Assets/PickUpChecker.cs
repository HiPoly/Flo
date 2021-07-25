using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpChecker : MonoBehaviour
{

    public bool enablesPlatformControl = false;
    public bool enablesSpiderManControl = false;

    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerState.canMovePlatforms && enablesPlatformControl) gameObject.SetActive(false);
        if (PlayerState.canSpiderMan && enablesSpiderManControl) gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            if (enablesPlatformControl)
            {
                collider.GetComponentInParent<PlayerState>().ActivateCanMovePlatform();

            }

            if (enablesSpiderManControl)
            {
                collider.GetComponentInParent<PlayerState>().ActivateCanSpiderMan();
            }

            Destroy(gameObject);
        }

    }
}
