using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;

    public int highScore = 0; // スコア変数

    //HighScore保存用
    public Text highScoreText;

    int score = 0;

    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        // スコアのロード
        highScore = PlayerPrefs.GetInt("SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (player.GetComponent<PlayerController>().GameStatus() == true && player.transform.position.x > 50 * i)
        {
            score++;
            i++;
            scoreText.text = score.ToString();
        }

        if (player.GetComponent<PlayerController>().GameStatus() == false)
        {
            if (score > highScore)
            {
                highScore = score;
            }
            highScoreText.text = "HighScore : " + highScore;

            if (Input.GetMouseButtonDown(0))
            {


                score = 0;
                scoreText.text = score.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ScorePoint")
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(other.gameObject, 0.2f);
        }
    }

    // 削除時の処理
    void OnDestroy()
    {
        // スコアを保存
        PlayerPrefs.SetInt("SCORE", highScore);
        PlayerPrefs.Save();
    }
}
