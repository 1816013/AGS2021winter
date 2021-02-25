using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCtr : MonoBehaviour
{
    public MapGenerator mapGen;
    List<GameObject> objs = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        // マップデータが出来てないとき
        if (objs.Count == 0)
        {         
            objs = mapGen.objs;
        }
        
        foreach (var obj in objs)
        {
            if (obj == null)
            {
                continue;
            }
            var block = obj.GetComponent<BreakBlock>();
            // コンポーネントがないオブジェクトをはじく
            if (block != null&& block.isActiveAndEnabled == true)
            {
                block.BreackUpdate();
            }
        }
    }
}
