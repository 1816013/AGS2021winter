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
        bedrock,
        treasure,
        max
    }
    public List<GameObject> objs = new List<GameObject>();
    public Vector3Int mapSize;
    public Vector2Int worldSize;
    public MapCtl mapCtl;
    public GameObject[] block;
    private float[][] dirtNoise;
    private float[][] coalNoise;
    private bool treasure = false;
    float maxDirtNoise = 0.0f;             //Noise値の最大を保存
    public float scl;
    Bounds bounds;
    GameObject chunk;

    BlockID[][][] mapData;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        GameObject floorplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GameObject ceilingplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floorplane.transform.localScale = new Vector3(0.4f * ((mapSize.x*worldSize.x)/2), 1.0f, 0.4f*((mapSize.z * worldSize.y) / 2));
        floorplane.transform.position = new Vector3(0, 0, ((worldSize.y / 2) * (mapSize.z * bounds.size.z * scl)));
        ceilingplane.transform.localScale = new Vector3(0.4f * ((mapSize.x * worldSize.x) / 2), 1.0f, 0.4f * ((mapSize.z * worldSize.y) / 2));
        ceilingplane.transform.position = new Vector3(0,bounds.size.y, ((worldSize.y / 2) * (mapSize.z * bounds.size.z * scl)));
        ceilingplane.transform.rotation = new Quaternion(0, 0, 90, 1);

        MakeNoise();

        for (int x = 0; x < worldSize.x; x++)
        {
            for (int y = 0; y < worldSize.x; y++)
            {
                var chunkPosX = (((x + 1) / 2) * ((((x + 1) % 2) * 2) - 1));
                MapInit(x, y);
                chunk = new GameObject("Chunk" + (4 + chunkPosX).ToString() + y.ToString());
                chunk.tag = "chunk";
                MapGenerate();
                mapCtl.bounds = bounds;
                mapCtl.scl = scl;
                chunk.transform.position = new Vector3((mapSize.x * (bounds.size.x * scl)) * chunkPosX, 0.0f, (mapSize.z * (bounds.size.z * scl)) * y);
                mapCtl.chunks[4 + chunkPosX][y] = chunk;
            }
        }
    }

    private void MakeNoise()
    {
        var dirtseed = Random.value*100;
        var coalseed = Random.value*100;
        for (int x = 0; x < dirtNoise.Length; x++)
        {
            for (int y = 0; y < dirtNoise[x].Length; y++)
            {
                dirtNoise[x][y] = Mathf.PerlinNoise(((x * bounds.size.x) + dirtseed) / 15, ((y * bounds.size.y + dirtseed)) / 15);
                if (maxDirtNoise <= dirtNoise[x][y])
                {
                    maxDirtNoise = dirtNoise[x][y];
                }
            }
        }
    }

    void MapInit(int chunkX,int chunkY)
    {
        var treasureChunk = new Vector2Int(Random.Range(0, worldSize.x + 1), Random.Range(0, worldSize.y + 1));
        var chunkPosX = (((chunkX + 1) / 2) * ((((chunkX + 1) % 2) * 2) - 1));

        mapData = new BlockID[mapSize.x][][];
        for (int x = 0; x < mapSize.x; x++)
        {
            mapData[x] = new BlockID[mapSize.y][];
            for (int y = 0; y < mapSize.y; y++)
            {
                mapData[x][y] = new BlockID[mapSize.z];
                for (int z = 0; z < mapSize.z; z++)
                {
                    LandFill(chunkX, chunkY, x, y, z);
                }
            }
        }

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                for (int z = 0; z < mapSize.z; z++)
                {
                    if (chunkX == 0)
                    {
                        if (x == mapSize.x / 2)
                        {
                            mapData[x][y][z] = (y == 0 ? BlockID.rail : BlockID.air);
                            mapData[x - 1][y][z] = BlockID.air;
                            mapData[x + 1][y][z] = BlockID.air;
                        }
                    }
                    else
                    {
                        if (!((Random.value * 100) % 100 <= 100 - ((Mathf.Abs(chunkPosX) + chunkY) / 2)))
                        {
                                mapData[x][y][z] = BlockID.gem;
                        }
                        if (treasure == false && treasureChunk == new Vector2Int(chunkX,chunkY)&& Random.Range(0,100) <= 10)
                        {
                            Debug.Log(treasureChunk);
                            mapData[x][y][z] = BlockID.treasure;
                            treasure = true;
                        }
                    }
                }
            }
        }
    }

    private void LandFill(int chunkX, int chunkY, int x, int y, int z)
    {
        var dirth = dirtNoise[x + mapSize.x * chunkX][z + mapSize.z * chunkY]; //dirtNoise値を保存

        if (dirth < (maxDirtNoise * 0.3))
        {
            mapData[x][y][z] = BlockID.dirt;
        }
        else if (dirth > (maxDirtNoise *0.7)&&dirth < (maxDirtNoise * 0.9))
        {
            mapData[x][y][z] = BlockID.bedrock;
        }
        else
        {
            mapData[x][y][z] = BlockID.stone;
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
                    GameObject gameObject = null;
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
                        case BlockID.bedrock:
                            gameObject = Instantiate(block[4], pos, Quaternion.identity);
                            gameObject.transform.parent = chunk.transform;
                            break;
                        case BlockID.treasure:
                            gameObject = Instantiate(block[5], pos, Quaternion.identity);
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
                    objs.Add(gameObject);
                }
            }
        }
    }

    void Init()
    {
        dirtNoise = new float[worldSize.x * mapSize.x][];
        for (int x = 0; x < dirtNoise.Length; x++)
        {
            dirtNoise[x] = new float[worldSize.y * mapSize.z];
        }

        foreach(var b in block)
        {
            b.transform.localScale = new Vector3(scl, scl, scl);
        }

        var tmpstone = block[0].transform.Find("default").gameObject;
        Debug.Log(tmpstone);
        bounds = tmpstone.GetComponent<MeshFilter>().sharedMesh.bounds;
    }
}
