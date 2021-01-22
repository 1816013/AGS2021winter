using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    private int cnt = 0;

    [SerializeField] GameObject panel;

    // Update is called once per frame
    void Update()
    {
        cnt++;
        if(cnt > 480)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }

    public void OnClickMenuButton()
    {
        panel.gameObject.SetActive(true);
    }
    public void OnClickGameButton()
    {
        panel.gameObject.SetActive(false);
    }
}
