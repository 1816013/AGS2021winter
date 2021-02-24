using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtl : MonoBehaviour
{
    public Transform player;
    public GameObject[][] chunks;
    Vector2Int chunkSize = new Vector2Int(20, 20);
    public float scl;
    public Bounds bounds;
    //Bounds playerBounds;
    // Start is called before the first frame update
    void Awake()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("chunk");
        chunks = new GameObject[chunkSize.x][];
        for (int y = 0; y < chunkSize.y; y++)
        {
            chunks[y] = new GameObject[chunkSize.y];
        }
        //playerBounds = player.GetComponent<MeshFilter>().sharedMesh.bounds;
    }

    // Update is called once per framea
    void Update()
    {
        if(player.position.x < 0)
        {
            Vector2Int index = new Vector2Int(4 + (int)((player.position.x - (chunkSize.x * bounds.size.x*scl)/2) / (chunkSize.x * bounds.size.x*scl)),
                                                (int)((player.position.z + (chunkSize.y * bounds.size.z*scl)/2) / (chunkSize.y * bounds.size.z*scl)));
         //   Debug.Log(chunks[index.x][index.y]);
        }
        else
        {
            Vector2Int index = new Vector2Int(4 + (int)((player.position.x + (chunkSize.x * bounds.size.x*scl)/2) / (chunkSize.x * bounds.size.x*scl)),
                                                (int)((player.position.z + (chunkSize.y * bounds.size.z*scl)/2) / (chunkSize.y * bounds.size.z*scl)));
         //   Debug.Log(chunks[index.x][index.y]);
        }
    }
}
