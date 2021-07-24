using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    bool isPlayerTouchingInteractable = false;
    bool isActivated = false;
    public UnityEvent onRemoteControlActivate;
    public UnityEvent onRemoteControlDeactivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerTouchingInteractable)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (isActivated == false)
                {
                    onRemoteControlActivate.Invoke();
                    isActivated = true;
                }
                else
                {
                    isActivated = false;
                    onRemoteControlDeactivate.Invoke();
                }
                
            }


        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            if (collider.GetComponentInParent<PlayerState>().canMovePlatforms)
            {

                isPlayerTouchingInteractable = true;
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Player"))
         {
            isPlayerTouchingInteractable = false;
        }
    }
}
