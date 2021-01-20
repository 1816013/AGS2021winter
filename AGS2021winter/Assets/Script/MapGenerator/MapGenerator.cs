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
        max
    }

    public Vector3Int mapSize;
    public Transform[] block;

    BlockID[][][] mapData;
    // Start is called before the first frame update
    void Start()
    {
        MapInit(); 
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
                            Instantiate(block[0], new Vector3(x * block[0].localScale.x * 4, y * block[0].localScale.y * 4, z * block[0].localScale.z * 4), Quaternion.identity);
                            break;
                        case BlockID.rail:
                            Instantiate(block[1], new Vector3(x * block[1].localScale.x * 4, y * block[1].localScale.y * 4, z * block[1].localScale.z * 4), Quaternion.identity);
                            break;
                        default:
                            Assert.IsFalse(id == BlockID.max, "BlockIDに想定されていない値が入っています。");
                            break;
                    }
                }
            }
        }
    }

    void MapInit()
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
                    if (y == 0)
                    {
                        mapData[x][y][z] = BlockID.stone;
                    }
                    else
                    {
                        if(mapData[x][y - 1][z] == BlockID.stone && x == 50)
                        {
                            mapData[x][y][z] = BlockID.rail;
                        }
                        else if (mapData[x][y - 1][z] == BlockID.rail)
                        {
                            mapData[x][y][z] = BlockID.air;
                        }
                        else
                        {
                            mapData[x][y][z] = BlockID.stone;
                        }
                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
