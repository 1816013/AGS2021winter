using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]
    [Header("------制限時間指定（秒）------")]
    public float limit;
    private int minutes;
    private int seconds;
    public Text text;
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        var tmp = limit;
        if (tmp / 60 >= 1)
        {
            tmp -= ((int)(limit / 60)) * 60;
            text.text = "残り" + ((int)(limit / 60)).ToString() + "分";
        }
        text.text = text.text + tmp.ToString() + "秒";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        var tmp = limit - time;
        text.text = "残り" + ((int)(tmp / 60)).ToString() + "分";
        text.text = text.text + ((int)((tmp- ((int)(tmp / 60)) * 60) % 60)).ToString() + "秒";
        if (time >= limit)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
