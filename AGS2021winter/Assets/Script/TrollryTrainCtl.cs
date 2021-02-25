using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrollryTrainCtl : MonoBehaviour
{
    public GameObject gameObject;
    public InventorySystem inventory;
    public MapCtl mapCtl;
    private int sumScore_;
    bool movef = true;              //直進してよいか
    bool onCursor_ = false;
    // Start is called before the first frame update
    void Start()
    {
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
            if (Input.GetMouseButton(0) && onCursor_)
            {
                sumScore_ += inventory.GetScore();
                inventory.Init();
                if(inventory.isFin())
                {
                    PlayerPrefs.SetInt("score", sumScore_);
                    SceneManager.LoadScene("ResultScene");
                }
                movef = false;
            }
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
    // ブロックにカーソルが重なった時
    public void OnCursorAct()
    {
        onCursor_ = true;
        //Debug.Log("hit");
    }
    // ブロックからカーソルが外れたとき
    public void ExitCursorAct()
    {
        onCursor_ = false;
        //Debug.Log("hit");
    }
}
