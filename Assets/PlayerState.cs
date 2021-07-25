using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool canMovePlatforms = false;
    public bool canSpiderMan = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCanMovePlatform()
    {
        canMovePlatforms = true;

    }
    
    public void ActivateCanSpiderMan()
    {

        canSpiderMan = true;

    }
    public void Die()
    {

        transform.position = new Vector2(0,0);

    }
}
