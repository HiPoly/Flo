using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompts : MonoBehaviour
{
    public GameObject PromptCanvas;
    public GameObject LockedIcon;
    public GameObject UnlockedIcon;
    
    private bool touching = true;
    private bool locked = false;
    //if player is within range of the object set touching to true

void Update(){
    if (touching){
        PromptCanvas.SetActive(true);

        if (locked){
            LockedIcon.SetActive(true);
            }
        else{
            LockedIcon.SetActive(false);
        }
        if(!locked){
            UnlockedIcon.SetActive(true);
        }
        else
            UnlockedIcon.SetActive(false);
        }
        else{
            PromptCanvas.SetActive(false);
        }
    }
}
