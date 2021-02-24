using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    [SerializeField][Range(0.2f, 5)]
    private float breakTime_;
    private float frame_;
    private bool onCursor_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void BreackUpdate()
    {
        // クリックしている間のみ加算
        if(Input.GetMouseButton(0) && onCursor_)
        {
            frame_ += Time.deltaTime;
        }
        else
        {
            frame_ = 0.0f;
        }
        // 一定時間クリックしていたら破壊
        if (frame_ > breakTime_)
        {
            this.gameObject.SetActive(false);
        }
    }
    // ブロックにカーソルが重なった時
    public void OnCursorAct()
    {
        onCursor_ = true;
        Debug.Log("hit");
    }
    // ブロックからカーソルが外れたとき
    public void ExitCursorAct()
    {
        onCursor_ = false;
        Debug.Log("hit");
    }
   
}
