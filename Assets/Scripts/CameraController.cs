using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player1, player2;

    private float cameraPosition;
    private float diff;
    private float scale = 15f;
    private Camera cam;

	void Start () {
        cam = GetComponent<Camera>();  
	}
	
	void Update () {
        cameraPosition = (player1.transform.position.x + player2.transform.position.x) / 2;
        gameObject.transform.position = new Vector3(cameraPosition, 0,-10);
	}

    void FixedUpdate() {
        diff = Mathf.Abs(player1.transform.position.x - player2.transform.position.x);
        if (diff > scale)
        {
            cam.orthographicSize *= 1.005f;
            scale *= 1.005f;
        }
        if (diff < scale && diff > 14.9f)
        {
            cam.orthographicSize /= 1.005f;
            scale /= 1.005f;
        }
    }

    public void SaveScore()
    {
        if (Application.loadedLevelName == "Level1")
        {
            if (player1.transform.position.x > player2.transform.position.x)
            {
                PlayerPrefs.SetInt("Player1", 1 + PlayerPrefs.GetInt("Player1"));
                PlayerPrefs.SetInt("Player2", 0 + PlayerPrefs.GetInt("Player2"));
            }
            else
            {
                PlayerPrefs.SetInt("Player2", 1 + PlayerPrefs.GetInt("Player2"));
                PlayerPrefs.SetInt("Player1", 0 + PlayerPrefs.GetInt("Player1"));
            }
        }
    }

}
