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
        dirt,
        max
    }

    public Vector3Int mapSize;
    public Vector2Int worldSize;
    public MapCtl mapCtl;
    public GameObject[] block;
    private float[][] noise;
    float maxNoize = 0.0f;             //Noise値の最大を保存
    public float scl;
    Bounds bounds;
    GameObject chunk;

    BlockID[][][] mapData;
    // Start is called before the first frame update
    void Start()
    {
        Mathf.PerlinNoise(0, 0);
        GameObject floorplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GameObject ceilingplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //obj.transform.position = new Vector3((mapSize.x * bounds.size.x*scl)/2, mapSize.y * bounds.size.y*scl, (mapSize.z * bounds.size.z*scl)/2);
        floorplane.transform.localScale = new Vector3(0.4f * mapSize.x, 1.0f, 0.4f * mapSize.z);
        floorplane.transform.position = new Vector3(0, 0, 0);
        ceilingplane.transform.localScale = new Vector3(0.4f * mapSize.x, 1.0f, 0.4f * mapSize.z);
        ceilingplane.transform.position = new Vector3(0, 8.0f, 0);
        ceilingplane.transform.rotation = new Quaternion(0, 0, 90, 1);

        block[0].transform.localScale = new Vector3(scl, scl, scl);
        block[1].transform.localScale = new Vector3(scl, scl, scl);
        block[2].transform.localScale = new Vector3(scl, scl, scl);
        block[3].transform.localScale = new Vector3(scl, scl, scl);

        var tmpstone = block[0].transform.Find("tmpstone");
        //Debug.Log(tmpstone);
        var tmpdefult = tmpstone.transform.Find("default").gameObject;
        //Debug.Log(tmpdefult);
        bounds = tmpdefult.GetComponent<MeshFilter>().sharedMesh.bounds;

        noise = new float[worldSize.x*mapSize.x][];
        for(int x = 0;x < noise.Length;x++)
        {
            noise[x] = new float[worldSize.y * mapSize.z];
        }

        for (int x = 0; x < noise.Length; x++)
        {
            for (int y = 0; y < noise[x].Length; y++)
            {
                noise[x][y] = Mathf.PerlinNoise((x*bounds.size.x)/15,(y * bounds.size.y)/15);
                if(maxNoize <= noise[x][y])
                {
                    maxNoize = noise[x][y];
                }
            }
        }
        //Instantiate(obj,, Quaternion.identity);
        for (int x = 0;x < worldSize.x;x++)
        {
            for (int y = 0; y < worldSize.x; y++)
            {
                MapInit(x,y);
                var chunkPosX = (((x + 1) / 2) * ((((x + 1) % 2) * 2) - 1));
                chunk = new GameObject("Chunk" + (4+chunkPosX).ToString() + y.ToString());
                chunk.tag = "chunk";
                MapGenerate();
                mapCtl.bounds = bounds;
                chunk.transform.position = new Vector3((mapSize.x * (bounds.size.x*scl)) * chunkPosX, 0.0f, (mapSize.z * (bounds.size.z*scl)) * y);
                mapCtl.chunks[4+chunkPosX][y] = chunk;
            }
        }
    }

    void MapInit(int chunkX,int chunkY)
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
                    if (chunkX == 0)
                    {
                        mapData[x][y][z] = BlockID.max;
                    }
                    else
                    {
                        
                        if ((Random.value * 100) % 100 <= 100 - (2 * (chunkX)))
                        {
                            if (noise[x + mapSize.x * chunkX][z + mapSize.z * chunkY] > (maxNoize * 0.3))
                            {
                                mapData[x][y][z] = BlockID.stone;
                            }
                            else
                            {
                                mapData[x][y][z] = BlockID.dirt;
                            }
                        }
                        else
                        {
                            mapData[x][y][z] = BlockID.gem;
                        }
                    }
                }
            }
        }
        if (chunkX == 0)
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
                        if ((Random.value * 100) % 100 <= 95 - (5 * chunkX))
                        {
                            if (noise[x + mapSize.x * chunkX][z + mapSize.z * chunkY] > (maxNoize * 0.3))
                            {
                                mapData[x][y][z] = BlockID.stone;
                            }
                            else
                            {
                                mapData[x][y][z] = BlockID.dirt;
                            }
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
                    var pos = new Vector3((mapSize.x * (bounds.size.x * scl)) / 2 - (x * (bounds.size.x * scl)) - 2,
                                            (y * (bounds.size.y * scl)),
                                            (mapSize.z * (bounds.size.x * scl)) / 2 - (z * (bounds.size.z * scl)) - 2);
                    var id = mapData[x][y][z];
                    GameObject gameObject;
                    switch (id)
                    {
                        case BlockID.air:
                            break;
                        case BlockID.stone:
                            gameObject = Instantiate(block[0], pos, Quaternion.identity);
                            gameObject.transform.parent = chunk.transform;
                            break;
                        case BlockID.gem:
                            gameObject = Instantiate(block[2], pos, Quaternion.identity);
                            gameObject.transform.parent = chunk.transform;
                            break;
                        case BlockID.dirt:
                            gameObject = Instantiate(block[3], pos, Quaternion.identity);
                            gameObject.transform.parent = chunk.transform;
                            break;
                        case BlockID.rail:
                            block[1].transform.localScale = new Vector3(scl, scl, scl);
                            gameObject = Instantiate(block[1], pos, Quaternion.identity);
                            gameObject.transform.parent = chunk.transform;
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
