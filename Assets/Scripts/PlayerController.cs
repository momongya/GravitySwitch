using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
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

        //Debug.Log(isPlaying);

        // ゲームがスタートした時
        if (isPlaying == false && gameStartCanvas.activeSelf == true)
        {
            //重力を停止させる
            playerRigidbody.isKinematic = false;

            if (Input.GetMouseButtonDown(0))
            {
                gameStartCanvas.SetActive(false);
                isPlaying = true;
            }
        }

        // リトライする時
        if (isPlaying == false && gameOverCanvas.activeSelf == true)
        {
            //重力を停止させる
            playerRigidbody.isKinematic = false;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(isPlaying);
                gameOverCanvas.SetActive(false);
                isPlaying = true;
            }
        }

        if (isPlaying == true)
        {
            //重力を可動させる
            playerRigidbody.isKinematic = false;

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
                isPlaying = false;
                gameOverCanvas.SetActive(true);
            }
        }
    }

    //今プレイ中かどうか
    public bool GameStatus()
    {
        return isPlaying;
    }
}
