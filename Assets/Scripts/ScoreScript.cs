using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;

    int score = 0;

    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().GameStatus() == true && player.transform.position.x > 20 * i)
        {
            score++;
            i++;
            scoreText.text = score.ToString();
        }
    }
}
