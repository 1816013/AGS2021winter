﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    private int cnt = 0;
    public bool flag = false;
    private bool isLoad=false;
    public GameObject Load;
    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isLoad = true;
            Load.SetActive(true);
        }
        if(isLoad)
        {
            //回す

        }
        if (flag)
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
