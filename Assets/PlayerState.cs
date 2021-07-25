using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    static public bool canMovePlatforms = false;
    static public bool canSpiderMan = false;

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
        GetComponent<PlayerController>().speaker.PlayOneShot(AudioManager.instance.upgrade);
    }
    
    public void ActivateCanSpiderMan()
    {

        canSpiderMan = true;
        GetComponent<PlayerController>().speaker.PlayOneShot(AudioManager.instance.upgrade);
    }
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //transform.position = new Vector2(0,0);
    }
}
