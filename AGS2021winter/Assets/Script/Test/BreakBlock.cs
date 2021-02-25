using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BreakBlock : MonoBehaviour
{
    [SerializeField][Range(0.2f, 5)]
    private float breakTime_;
    private float frame_;
    private bool onCursor_;
    private bool breackFlag_;
    public int id;

    //コールバック前準備
    [Serializable] private class BreackEvent : UnityEvent<AddInventory> { }
    [SerializeField] private BreackEvent breackEvent = null;

    //デリゲートの宣言
    public delegate void delFunc(AddInventory inventory);

    private bool IsDone { get; set; }
    public void Init(delFunc callback)
    {
        UnityAction<AddInventory> systemListner = new UnityAction<AddInventory>(callback);
        breackEvent.AddListener(systemListner);
    }

    // Start is called before the first frame update
    void Start()
    {
        IsDone = false;
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
            BreackFunc();
            this.gameObject.SetActive(false);
        }
    }

    public void BreackFunc()
    {
        if (!IsDone)
        {
            AddInventory add = new AddInventory(this.gameObject);

            IsDone = true;
            breackEvent.Invoke(add);
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
    public class AddInventory
    {
        public GameObject obj;
        public AddInventory(GameObject obj)
        {
            this.obj = obj;
        }
    }
}
