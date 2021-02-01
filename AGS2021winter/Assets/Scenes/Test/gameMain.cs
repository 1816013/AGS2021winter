using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMain : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10000; i++)
        {

            Instantiate(prefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
