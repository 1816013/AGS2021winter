using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using Gs2.Core;
using Gs2.Unity.Gs2Account.Model;
using Gs2.Unity.Gs2Account.Result;
using Gs2.Unity.Util;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

    private Gs2.Unity.Client gs2 = Login.gs2;
    private GameSession gameSession = Login.session;

    public Text Money_text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MenueSetUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator MenueSetUp()
    {
        Debug.Log("課金通貨の確保");
        {
            yield return gs2.Money.Get(
                r => {
                    if (r.Error != null)
                    {
                        // エラーが発生した場合に到達
                        // r.Error は発生した例外オブジェクトが格納されている
                        Login.OnError(r.Error);
                    }
                    else
                    {
                        Debug.Log(r.Result.Item.Slot); // integer スロット番号
                        Debug.Log(r.Result.Item.Paid); // integer 有償課金通貨所持量
                        Debug.Log(r.Result.Item.Free); // integer 無償課金通貨所持量
                        Debug.Log(r.Result.Item.UpdatedAt); // long 最終更新日時
                        Money_text.text ="×"+ (r.Result.Item.Free + r.Result.Item.Paid).ToString();
                    }
                },
                gameSession,    // GameSession ログイン状態を表すセッションオブジェクト
                "gem",   //  ネームスペースの名前
                0   //  スロット番号
            );


        }
    }
    public void MoneyUpdate()
    {
        StartCoroutine(MenueSetUp());
    }
    private void OnApplicationQuit()
    {
        Login.profile.Finalize();
        
    }
}
