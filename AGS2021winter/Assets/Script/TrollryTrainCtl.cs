using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollryTrainCtl : MonoBehaviour
{
    public GameObject gameObject;
    public MapCtl mapCtl;
    bool movef = true;              //直進してよいか
    // Start is called before the first frame update
    void Start()
    {
        movef = true;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = gameObject.transform.position.z - (mapCtl.GetChunkSize().y / 2) * mapCtl.GetBounds().size.z*mapCtl.GetScl();
        var halfSize = (mapCtl.GetBounds().size.z * mapCtl.GetScl()) / 2;
        if (movef==true && pos<=(mapCtl.centerChunk.y+1)*(mapCtl.GetChunkSize().y/2)*mapCtl.GetBounds().size.z*mapCtl.GetScl()-halfSize)
        {
            movef = true;
            gameObject.transform.position += new Vector3(0.0f, 0.0f, 0.05f);
        }
        else
        {
            movef = false;
        }
        if (movef==false && pos>= -((mapCtl.GetChunkSize().y / 2) * mapCtl.GetBounds().size.z * mapCtl.GetScl())*2)
        {
            gameObject.transform.position -= new Vector3(0.0f, 0.0f, 0.05f);
        }
        else
        {
            movef = true;
        }
    }
}
