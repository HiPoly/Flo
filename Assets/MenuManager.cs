using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string currentMenu = "Main";
    public GameObject MainCanvas;
    public GameObject SelectCanvas;
    public GameObject CreditsCanvas;
    

    //HideUnused
    void Update()
    {
        if (currentMenu == "Main"){
            MainCanvas.SetActive(true);
        }
        else{
            MainCanvas.SetActive(false);
        }
        if (currentMenu == "Select"){
            SelectCanvas.SetActive(true);
        }
        else{
            SelectCanvas.SetActive(false);
        }
        if (currentMenu == "Credits"){
            CreditsCanvas.SetActive(true);
        }
        else{
            CreditsCanvas.SetActive(false);
        }
    }

    //ChangeActiveScene
    public void SetMain(){
        currentMenu = "Main";
    }
    public void SetSelect(){
        currentMenu = "Select";
    }
    public void SetCredits(){
        currentMenu = "Credits";
    }
    
    //LoadScene
    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
