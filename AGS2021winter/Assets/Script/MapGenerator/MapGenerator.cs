using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MapGenerator : MonoBehaviour
{
    enum BlockID
    {
        air,
        rail,
        stone,
        gem,
        max
    }

    public Vector3Int mapSize;
    public Vector2Int worldSize;
    public MapCtl mapCtl;
    public GameObject[] block;
    Bounds bounds;
    GameObject chunk;

    BlockID[][][] mapData;
    // Start is called before the first frame update
    void Start()
    {
        GameObject floorplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GameObject ceilingplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //obj.transform.position = new Vector3((mapSize.x * block[0].transform.localScale.x * 4)/2, mapSize.y * block[0].transform.localScale.y * 4, (mapSize.z * block[0].transform.localScale.z * 4)/2);
        floorplane.transform.localScale = new Vector3(0.4f * mapSize.x, 1.0f, 0.4f * mapSize.z);
        ceilingplane.transform.localScale = new Vector3(0.4f * mapSize.x, 1.0f, 0.4f * mapSize.z);
        floorplane.transform.position = new Vector3(0, 0, 0);
        ceilingplane.transform.position = new Vector3(0, 8.0f, 0);
        ceilingplane.transform.rotation = new Quaternion(0, 0, 90, 1);
        //Instantiate(obj,, Quaternion.identity);
        for (int x = 0;x < worldSize.x;x++)
        {
            for (int y = 0; y < worldSize.x; y++)
            {
                MapInit(x);
                var chunkPosX = (((x + 1) / 2) * ((((x + 1) % 2) * 2) - 1));
                chunk = new GameObject("Chunk" + (4+chunkPosX).ToString() + y.ToString());
                chunk.tag = "chunk";
                MapGenerate();
                var tmpstone = block[0].transform.Find("tmpstone");
                //Debug.Log(tmpstone);
                var tmpdefult = tmpstone.transform.Find("default").gameObject;
                //Debug.Log(tmpdefult);
                bounds = tmpdefult.GetComponent<MeshFilter>().sharedMesh.bounds;
                mapCtl.bounds = bounds;
                chunk.transform.position = new Vector3((mapSize.x * bounds.size.x) * chunkPosX, 0.0f, (mapSize.z * bounds.size.z) * y);
                mapCtl.chunks[4+chunkPosX][y] = chunk;
            }
        }
    }



    void MapInit(int chunkCnt)
    {
        mapData = new BlockID[mapSize.x][][];
        for (int x = 0; x < mapSize.x; x++)
        {
            mapData[x] = new BlockID[mapSize.y][];
            for (int y = 0; y < mapSize.y; y++)
            {
                mapData[x][y] = new BlockID[mapSize.z];
                for (int z = 0; z < mapSize.z; z++)
                {
                    if (chunkCnt == 0)
                    {
                        mapData[x][y][z] = BlockID.max;
                    }
                    else
                    {
                        if((Random.value*100)%100 <= 100 - (2 * (chunkCnt)))
                        {
                            mapData[x][y][z] = BlockID.stone;
                        }
                        else
                        {
                            mapData[x][y][z] = BlockID.gem;
                        }
                    }
                }
            }
        }
        if (chunkCnt == 0)
        {
            for (int x = 0; x < mapSize.x; x++)
            {
                for (int y = 0; y < mapSize.y; y++)
                {
                    for (int z = 0; z < mapSize.z; z++)
                    {
                        if (mapData[x][y][z] != BlockID.max)
                        {
                            continue;
                        }
                        if ((Random.value * 100) % 100 <= 95 -(5*chunkCnt))
                        {
                            mapData[x][y][z] = BlockID.stone;
                        }
                        else
                        {
                            mapData[x][y][z] = BlockID.gem;
                        }
                        if (x == mapSize.x / 2)
                        {
                            if (y == 0)
                            {
                                mapData[x][y][z] = BlockID.rail;
                            }
                            else
                            {
                                mapData[x][y][z] = BlockID.air;
                            }
                            mapData[x - 1][y][z] = BlockID.air;
                            mapData[x + 1][y][z] = BlockID.air;
                        }
                    }
                }
            }
        }
    }
    void MapGenerate()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                for (int z = 0; z < mapSize.z; z++)
                {
                    var id = mapData[x][y][z];
                    switch (id)
                    {
                        case BlockID.air:
                            break;
                        case BlockID.stone:
                            var stone = Instantiate(block[0], new Vector3((mapSize.x * (block[0].transform.localScale.x * 4)) / 2 - (x * (block[0].transform.localScale.x * 4)) - 2, (y * (block[0].transform.localScale.y * 4)), (mapSize.z * (block[0].transform.localScale.x * 4)) / 2 - (z * (block[0].transform.localScale.z * 4)) - 2), Quaternion.identity);
                            stone.transform.parent = chunk.transform;
                            break;
                        case BlockID.gem:
                            var jem = Instantiate(block[2], new Vector3((mapSize.x * (block[0].transform.localScale.x * 4)) / 2 - (x * (block[0].transform.localScale.x * 4)) - 2, (y * (block[0].transform.localScale.y * 4)), (mapSize.z * (block[0].transform.localScale.x * 4)) / 2 - (z * (block[0].transform.localScale.z * 4)) - 2), Quaternion.identity);
                            jem.transform.parent = chunk.transform;
                            break;
                        case BlockID.rail:
                            var rail = Instantiate(block[1], new Vector3((mapSize.x * (block[1].transform.localScale.x * 4)) / 2 - (x * (block[1].transform.localScale.x * 4)) - 2, (y * (block[1].transform.localScale.y * 4)), (mapSize.z * (block[1].transform.localScale.z * 4)) / 2 - (z * (block[1].transform.localScale.z * 4)) - 2), Quaternion.identity);
                            rail.transform.parent = chunk.transform;
                            break;
                        default:
                            Assert.IsFalse(id == BlockID.max, "BlockIDに想定されていない値が入っています。");
                            break;
                    }
                }
            }
        }
    }
    
    BlockID GemGenerator(int chunkId)
    {
        switch (chunkId)
        {
            case 0:
                break;
        }
        return BlockID.stone;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
