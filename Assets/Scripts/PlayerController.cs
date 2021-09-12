using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    int playerSpeed = 12;

    float x;
    float y;
    Rigidbody playerRigidbody;

    public GameObject gameStartCanvas;
    public GameObject gameOverCanvas;
    public GameObject player;
    public GameObject came;

    public ParticleSystem gameOverParticle;

    bool isPlaying = false;
    bool clickAction = false;

    //今ゲームを初めてすぐ(true)かリトライした後(false)かの判別
    bool nowStatus = true;

    MeshRenderer mr;

    [SerializeField] private Renderer a;//Renderer型の変数aを宣言　好きなゲームオブジェクトをアタッチ


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // ゲームがスタートした時
        if (isPlaying == false && gameStartCanvas.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameStartCanvas.SetActive(false);
                isPlaying = true;
            }
        }

        // リトライする時
        if (isPlaying == false && gameOverCanvas.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Retry();
            }
        }

        if (isPlaying == true)
        {
            //重力を可動させる
            playerRigidbody.isKinematic = false;

            nowStatus = true;

            //プレイヤーを動かす
            transform.position += transform.right * playerSpeed * Time.deltaTime;

            //カメラを動かす
            came.gameObject.transform.position += transform.right * playerSpeed * Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                if (clickAction == false)
                {
                    Physics.gravity = new Vector3(0, 29.4f, 0);
                    clickAction = true;
                }
                else if (clickAction == true)
                {
                    Physics.gravity = new Vector3(0, -29.4f, 0);
                    clickAction = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScoreWall")
        {
            GameOver();
            StartCoroutine("ChangeParticle");
        }
    }

    //ゲームオーバー時の挙動
    void GameOver()
    {
        //重力を停止させる
        playerRigidbody.isKinematic = false;

        isPlaying = false;
        gameOverCanvas.SetActive(true);

        nowStatus = false;

        a.enabled = false;
    }

    void Retry()
    {
        player.transform.position = new Vector3(0, 0, 0);
        came.transform.position = new Vector3(0, 0, -20);

        gameOverCanvas.SetActive(false);
        isPlaying = true;
        gameOverParticle.Stop();

        a.enabled = true;
    }

    IEnumerator ChangeParticle()
    {
        gameOverParticle.Play();

        //1秒停止
        yield return new WaitForSeconds(1);

        gameOverParticle.Stop();

        //コルーチン停止
        yield break;
    }


    //今プレイ中かどうか
    public bool GameStatus()
    {
        return isPlaying;
    }

    //今リトライボタンが押されたかどうか
    public bool RetryStatus()
    {
        return nowStatus;
    }

    //プレイヤーのスピードを返すだけ
    public int PlayerSpeed()
    {
        return playerSpeed;
    }
}
