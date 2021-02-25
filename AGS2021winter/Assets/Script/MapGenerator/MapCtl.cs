using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtl : MonoBehaviour
{
    public Transform player;
    public InventorySystem inventory;
    public GameObject[][] chunks;
    public Vector2 centerChunk;
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
        GetChunk(player.position);
    }
    public Vector2Int GetChunk(Vector3 pos)
    {
        Vector2Int index;
        if (pos.x < 0)
        {
            index = new Vector2Int(4 + (int)((pos.x - (chunkSize.x * bounds.size.x * scl) / 2) / (chunkSize.x * bounds.size.x * scl)),
                                             (int)((pos.z + (chunkSize.y * bounds.size.z * scl) / 2) / (chunkSize.y * bounds.size.z * scl)));
            //   Debug.Log(chunks[index.x][index.y]);
        }
        else
        {
            index = new Vector2Int((int)((pos.x + (chunkSize.x * bounds.size.x * scl) / 2) / (chunkSize.x * bounds.size.x * scl)),
                                             (int)((pos.z + (chunkSize.y * bounds.size.z * scl) / 2) / (chunkSize.y * bounds.size.z * scl)));
            //   Debug.Log(chunks[index.x][index.y]);
        }
        return index;
    }
    public void GetBlockData(GameObject obj)
    {   
        inventory.AddInventory(obj);
    }
    public Vector2Int GetChunkSize()
    {
        return chunkSize;
    }
    public void SetBounds(Bounds bound)
    {
        bounds = bound;
    }
    public Bounds GetBounds()
    {
        return bounds;
    }
    
    public void SetScl(float size)
    {
        scl = size;
    }
    public float GetScl()
    {
        return scl;
    }
}
