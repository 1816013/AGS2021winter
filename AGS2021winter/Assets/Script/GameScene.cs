using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public int cnt = 0;
    // Update is called once per frame
    void Update()
    {
        cnt++;
        if(cnt > 480)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
