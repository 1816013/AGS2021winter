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
        GameObject floorplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GameObject ceilingplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //obj.transform.position = new Vector3((mapSize.x * block[0].localScale.x * 4)/2, mapSize.y * block[0].localScale.y * 4, (mapSize.z * block[0].localScale.z * 4)/2);
        floorplane.transform.localScale = new Vector3(0.4f*mapSize.x,1.0f,0.4f*mapSize.z);
        ceilingplane.transform.localScale = new Vector3(0.4f*mapSize.x,1.0f,0.4f*mapSize.z);
        floorplane.transform.position = new Vector3(0,0,0);
        ceilingplane.transform.position = new Vector3(0,8.0f,0);
        ceilingplane.transform.rotation = new Quaternion( 0, 0,90,1);
        //Instantiate(obj,, Quaternion.identity);

        MapInit(); 
                     
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                for (int z = 0; z < mapSize.z; z++)
                {
                    var id = mapData[x][y][z];switch (id)
                    {
                        case BlockID.air:
                            break;
                        case BlockID.stone:
                            Instantiate(block[0], new Vector3((mapSize.x * (block[0].localScale.x * 4))/2-(x *(block[0].localScale.x * 4))-2, (y * (block[0].localScale.y * 4)), (mapSize.z * (block[0].localScale.x * 4)) / 2 - (z * (block[0].localScale.z * 4)) - 2), Quaternion.identity);
                             break;
                        case BlockID.rail:
                            Instantiate(block[1], new Vector3((mapSize.x * (block[1].localScale.x * 4))/2 - (x * (block[1].localScale.x * 4)) - 2, (y * (block[1].localScale.y * 4)), (mapSize.z * (block[1].localScale.z * 4)) / 2 - (z * (block[1].localScale.z * 4)) - 2), Quaternion.identity);
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
                    mapData[x][y][z] = BlockID.max;
                }
            }
        }
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
                    mapData[x][y][z] = BlockID.stone;
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
