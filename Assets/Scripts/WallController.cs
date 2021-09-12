using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{

    float delayUntilDestroyed = 100;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delayUntilDestroyed);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().GameStatus() == false)
        {
            if (Input.GetMouseButtonDown(0) && transform.position.x >= 30)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void DestroyWall()
    {
        
    }
}
