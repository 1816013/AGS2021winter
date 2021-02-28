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
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{
    // GS2-Identifier で発行したクライアントID
    public string clientId;

    // GS2-Identifier で発行したクライアントシークレット
    public string clientSecret;

    // アカウントを作成する GS2-Account のネームスペース名
    public string accountNamespaceName;

    // アカウントの認証結果に付与する署名を計算するのに使用する暗号鍵
    public string accountEncryptionKeyId;
  
    private bool isSatart = false;
    //ログイン状態を表すゲームセッションオブジェクト
    public static GameSession session = null;
    public static Gs2.Unity.Client gs2 = null;
    public static Profile profile = null;
    public static StampSheetStateMachine machine=null;
    public GameObject titleScene;
    void Start()
    {
    }
    public void onClick()
    {
        StartCoroutine(CreateAndLoginAction());

        //StartCoroutine(CreateAndLoginAction());
    }

    public IEnumerator CreateAndLoginAction()
    {
        if (isSatart)
        {
            yield break;
        }
        string filePath;
#if !UNITY_EDITOR && UNITY_ANDROID
    filePath=Application.persistentDataPath+"/accountData.bad";

#else
        // TODO: 本来は各プラットフォームに対応した処理が必要
    filePath = "./accountData.bad";
#endif

    Debug.Log(filePath);
        // GS2 SDK のクライアントを初期化


        Debug.Log("GS2 SDK のクライアントを初期化");

        profile = new Gs2.Unity.Util.Profile(
            clientId: clientId,
            clientSecret: clientSecret,
            reopener: new Gs2BasicReopener()
        );

        {
            AsyncResult<object> asyncResult = null;

            var current = profile.Initialize(
                r => { asyncResult = r; }
            );

            yield return current;

            // コルーチンの実行が終了した時点で、コールバックは必ず呼ばれています

            // クライアントの初期化に失敗した場合は終了
            if (asyncResult.Error != null)
            {
                OnError(asyncResult.Error);
                yield break;
            }
        }
        EzAccount account = null;
        gs2 = new Gs2.Unity.Client(profile);
        //ファイルが存在するか確認する。
        if (!File.Exists(filePath))
        {


            // アカウントを新規作成

            Debug.Log("アカウントを新規作成");


            {
                AsyncResult<EzCreateResult> asyncResult = null;

                var current = gs2.Account.Create(
                    r => { asyncResult = r; },
                    accountNamespaceName
                );

                yield return current;

                // コルーチンの実行が終了した時点で、コールバックは必ず呼ばれています

                // アカウントが作成できなかった場合は終了
                if (asyncResult.Error != null)
                {
                    OnError(asyncResult.Error);
                    yield break;
                }

                // 作成したアカウント情報を取得
                account = asyncResult.Result.Item;

                //作成したアカウント情報を保存
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(filePath);

                try
                {
                    // 指定したオブジェクトを上で作成したストリームにシリアル化する
                    bf.Serialize(file, account);
                }
                finally
                {
                    // ファイル操作には明示的な破棄が必要です。Closeを忘れないように。
                    if (file != null)
                        file.Close();
                }

            }
        }



        {
            // バイナリ形式でデシリアライズ
            BinaryFormatter bf = new BinaryFormatter();
            // 指定したパスのファイルストリームを開く
            FileStream file = File.Open(filePath, FileMode.Open);

            try
            {
                // 指定したファイルストリームをオブジェクトにデシリアライズ。
                account = (EzAccount)bf.Deserialize(file);
            }
            finally
            {
                // ファイル操作には明示的な破棄が必要です。Closeを忘れないように。
                if (file != null)
                    file.Close();
            }
        }
        // ログイン

        Debug.Log("ログイン");



        {
            AsyncResult<GameSession> asyncResult = null;
            var current = profile.Login(
               authenticator: new Gs2AccountAuthenticator(
                   session: profile.Gs2Session,
                   accountNamespaceName: accountNamespaceName,
                   keyId: accountEncryptionKeyId,
                   userId: account.UserId,
                   password: account.Password
               ),
               r => { asyncResult = r; }
           );

            yield return current;

            // コルーチンの実行が終了した時点で、コールバックは必ず呼ばれています

            // ゲームセッションオブジェクトが作成できなかった場合は終了
            if (asyncResult.Error != null)
            {
                OnError(asyncResult.Error);
                yield break;
            }

            // ログイン状態を表すゲームセッションオブジェクトを取得
            session = asyncResult.Result;

        }
        Debug.Log("ログイン完了");
        titleScene.GetComponent<TitleScene>().flag = true;
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CreateAndLoginAction());
        }
        if (isSatart)
        {
            //SceneManager.LoadScene("testNext");

        }
    }
    public static void OnError(Exception e)
    {
        Debug.LogError(e.ToString());
    }
    private void OnApplicationQuit()
    {
        if(Login.profile!=null)
        {
            Login.profile.Finalize();
        }

    }

}
