using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    public void OnClickGameButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnClickShopButton()
    {
        SceneManager.LoadScene("ShopScene");
    }
    public void OnClickMainButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
