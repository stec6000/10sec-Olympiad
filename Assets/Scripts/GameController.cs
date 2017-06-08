using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public CameraController camera;
    public Text text;
    public Text countdownFirst;
    public enum Direction { Up, Down, Right, Left };

    private float countdown = 10f;
    private float changeArrowTimer = 0f;
    private float timeBetweenChnage = 0.5f;
    private bool pause = true;    
    private Direction direction;

	void Start () {
        direction = Direction.Up;
        StartCoroutine(Countdown());
    }
	
	void Update () {

        if (!pause)
        {
            countdown -= Time.deltaTime;
            changeArrowTimer += Time.deltaTime;
            text.text = Math.Round(countdown, 2).ToString();


            if (changeArrowTimer > timeBetweenChnage)
            {
                Rotate();

                changeArrowTimer -= timeBetweenChnage;
            }
        if(countdown <= 0)
            {

                if (Application.loadedLevelName == "Level1")
                {
                    camera.SaveScore();
                    SceneManager.LoadScene("Scores");
                }
                if (Application.loadedLevelName == "Level2")
                {
                    SceneManager.LoadScene("Final");
                }
            }

        }
	}

    private Direction ChangeDirection()
    {
        int rand = UnityEngine.Random.Range(0, 4);
        while (rand == (int)direction)
        {
            rand = UnityEngine.Random.Range(0, 4);
        }
        Direction dir = (Direction)rand;
        return dir;
    }

    public void Rotate()
    {
        direction = ChangeDirection();
        switch (direction)
        {
            case Direction.Up:
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direction.Down:
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case Direction.Right:
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case Direction.Left:
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }
    }

    public IEnumerator Countdown()
    {
        countdownFirst.text = "3";
        yield return new WaitForSeconds(1);
        countdownFirst.text = "2";
        yield return new WaitForSeconds(1);
        countdownFirst.text = "1";
        yield return new WaitForSeconds(1);
        Destroy(countdownFirst);
        pause = false;
    }

    public Direction GetDirection()
    {
        return direction;
    }
}
