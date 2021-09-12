using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject player;

    float timer = 0;
    float interval = 0.8f;

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
            transform.position = new Vector3(12+i, Random.Range(3.0f, 4.5f), 0);
            Instantiate(topWall, transform.position, transform.rotation);

            //下側の壁生成
            transform.position = new Vector3(12+i, Random.Range(-4.5f, -3.0f), 0);
            Instantiate(bottomWall, transform.position, transform.rotation);

            timer = 0;
            i += 4;
        }
        }
    }
}
