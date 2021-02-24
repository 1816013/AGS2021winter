using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    private int cnt = 0;
    private bool flag = false;
    private void Start()
    {
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            flag = true;
        }
        if(flag)
        {
            cnt++;
            if (cnt > 60)
            {
                SceneManager.LoadScene("MainScene");
                cnt = 0;
                flag = false;
            }
        }
    }
}
