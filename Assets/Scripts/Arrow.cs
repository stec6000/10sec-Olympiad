using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour {

    private string key;
    private bool strike = false;
    private GameObject player;
    private float distance;
    private GameObject arrow;
    private float timer = 0f;

	void Start () {
        //rig = GetComponent<Rigidbody2D>();
        player = gameObject.transform.parent.gameObject;
        arrow = Resources.Load("arrow") as GameObject;
        if (player.name == "Player1") key = "e";
        else key = "o";
    }
	
	void Update () {
        timer += Time.deltaTime;

        if (timer > 3)
        {
            if (Input.GetKey(key))
            {
                gameObject.transform.Rotate(new Vector3(0, 0, -10));
            }

            if (Input.GetKeyUp(key))
            {
                strike = true;
                //Debug.Log(Math.Tan(gameObject.transform.rotation.z));
                // gameObject.transform.Translate(new Vector3(0, 0.3f, 0));
            }
            if (strike)
            {
                gameObject.transform.Translate(new Vector3(0, 0.2f, 0));
            }
            else gameObject.transform.position = player.transform.position;

            distance = Mathf.Sqrt((player.transform.position.x - gameObject.transform.position.x) * (player.transform.position.x - gameObject.transform.position.x) +
                (player.transform.position.y - gameObject.transform.position.y) * (player.transform.position.y - gameObject.transform.position.y));

            if (distance > 15)
            {
                Destroy(gameObject);
                Instantiate(arrow, player.transform);
            }
        }
    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject != player)
        {
            PlayerPrefs.SetInt(player.name, 1 + PlayerPrefs.GetInt(player.name));
            SceneManager.LoadScene("Final");
        }
    }


}
