using System;
using System.Collections;
using System.Collections.Generic;
using Gs2.Core;
using Gs2.Core.Exception;
using Gs2.Unity.Gs2Account.Model;
using Gs2.Unity.Gs2Account.Result;
using Gs2.Unity.Util;
using UnityEngine;
using UnityEngine.Events;

public class Result : MonoBehaviour
{
    private Gs2.Unity.Client gs2 = Login.gs2;
    private GameSession gameSession = Login.session;

    public Money money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGem()
    {
        StartCoroutine(GetGem());
    }
   
    //UnityEvent<Gs2Exception>型を使用するための準備
    [System.Serializable]
    public class OnErrorCallback : UnityEngine.Events.UnityEvent<Gs2Exception>
    {
    }

    //スタンプシート実行エラー時の動作を定義
    private void OnError(Exception e)
    {
        Debug.LogError(e.ToString());
    }
 private IEnumerator GetGem()
    {


        var result = gs2.Showcase.Buy(
        r =>
        {
            if (r.Error != null)
            {
                Login.OnError(r.Error);
            }
            else
            {
                Debug.Log(r.Result.Item);
                Debug.Log(r.Result.StampSheetEncryptionKeyId);
                Login.machine = new StampSheetStateMachine(r.Result.StampSheet, gs2, r.Result.StampSheetEncryptionKeyId);
                Debug.Log(Login.machine.ToString());
               
            }
        },
        gameSession,
        "AddGem",
        "AddGem",
        "55dce6d7-7c3a-4539-8c4b-4f3e52093d2f"
        );
        yield return result;

        UnityEvent<Gs2Exception> m_events = new OnErrorCallback();
        m_events.AddListener(OnError);
        yield return Login.machine.Execute(m_events);
        Debug.Log("StampSheetStateMachineの実行");


        money.MoneyUpdate();

    }
}
