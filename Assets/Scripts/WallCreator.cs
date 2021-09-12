using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject player;
    public GameObject scorePoint;

    float timer = 0;
    float interval = 0.5f;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().GameStatus()== true)
        {

            timer += Time.deltaTime;

            if (timer >= interval)
            {
                //上側の壁生成
                transform.position = new Vector3(26 + 8*i, Random.Range(9, 14), 0);
                Instantiate(topWall, transform.position, transform.rotation);

                //下側の壁生成
                transform.position = new Vector3(26 + 8*i, Random.Range(-14, -9), 0);
                Instantiate(bottomWall, transform.position, transform.rotation);

                if (i%5 == 0)
                {
                    transform.position = new Vector3(Random.Range(26 + 8 * i, 31 + 8 * i), Random.Range(-3, 3), 0);
                    Instantiate(scorePoint, transform.position, transform.rotation);
                }

                timer = 0;
                i++;
            }

        }
    }
}
