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
        
    }
}
