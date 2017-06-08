using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public Image howTo;
    public Button back;
    public Canvas howToCanvas;

	void Start () {
        howToCanvas.enabled = false;
        //howTo.enabled = false;
       // back.enabled = false;

	}
	
	void Update () {
		
	}

    public void Play()
    {

        PlayerPrefs.SetInt("Player1", 0);
        PlayerPrefs.SetInt("Player2", 0);
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        Application.Quit();
    }
    
    public void HowTo()
    {
        howToCanvas.enabled = true;
    }

    public void Back()
    {
        howToCanvas.enabled = false;
    }
}
