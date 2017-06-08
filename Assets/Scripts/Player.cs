using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject arrow;
    public string[] keys;
    public GameObject direction;

    private Rigidbody2D rig;
    private float time = 0f;
    private int dir;
    private string keyPressed;
    private string level;
    

	void Start () {
        rig = GetComponent<Rigidbody2D>();
        level = Application.loadedLevelName;
	}
	
	void Update () {

        if (level == "Level1")
        {
            dir = (int)direction.GetComponent<GameController>().GetDirection();
            time += Time.deltaTime;
            keyPressed = Input.inputString;

            for (int i = 0; i < 4; i++)
            {
                if (keys[i] == keyPressed && i == dir)
                {
                    rig.AddForce(new Vector2(200, 0), ForceMode2D.Force);
                }
            }
        }
        
	}
    
}
