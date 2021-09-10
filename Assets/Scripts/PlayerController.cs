using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 10;

    float x;
    float y;
    Rigidbody playerRigidbody;

    public GameObject gameStartCanvas;
    public GameObject gameOverCanvas;

    bool isPlaying = false;
    bool clickAction = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == false)
        {
            if (Input.GetMouseButton(0))
            {
                isPlaying = true;
                gameStartCanvas.SetActive(false);
                gameOverCanvas.SetActive(false);
            }
        }

        if (isPlaying == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (clickAction == false)
                {
                    Physics.gravity = new Vector3(0, 9.8f, 0);
                    clickAction = true;
                }
                else if (clickAction == true)
                {
                    Physics.gravity = new Vector3(0, -9.8f, 0);
                    clickAction = false;
                }
            }

            if (transform.position.x < 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        isPlaying = false;
        gameOverCanvas.SetActive(true);

        if (Input.GetMouseButton(0))
        {

        }
    }

    public bool GameStatus()
    {
        return isPlaying;
    }
}
