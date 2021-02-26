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


public class Gacha : MonoBehaviour
{
    private Gs2.Unity.Client gs2 = Login.gs2;
    private GameSession gameSession = Login.session;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnOnceGacha()
    {
        StartCoroutine(GachaLoad(1));
    }
    public void OnTenthgacha()
    {
        StartCoroutine(GachaLoad(10));
    }
    private IEnumerator GachaLoad(int num)
    {
        if (num == 1)
        {
            yield return gs2.Showcase.Buy(
               r =>
               {
                   if (r.Error != null)
                   {
                       // エラーが発生した場合に到達
                       // r.Error は発生した例外オブジェクトが格納されている
                       Login.OnError(r.Error);
                   }
                   else
                   {
                       Debug.Log(r.Result.Item.Name); // string 商品名
                       Debug.Log(r.Result.Item.Metadata); // string 商品のメタデータ
                       Debug.Log(r.Result.Item.ConsumeActions); // list[ConsumeAction] 消費アクションリスト
                       Debug.Log(r.Result.Item.AcquireActions); // list[AcquireAction] 入手アクションリスト
                       Debug.Log(r.Result.StampSheet); // string 購入処理の実行に使用するスタンプシート
                       Debug.Log(r.Result.StampSheetEncryptionKeyId); // string スタンプシートの署名計算に使用した暗号鍵GRN
                   }
               },
               gameSession,    // GameSession ログイン状態を表すセッションオブジェクト
               "gemGacha",   //  ネームスペース名
               "gem1",      //  商品名
               "gemGacha"   //  陳列商品ID
           );
        }

    }
}
