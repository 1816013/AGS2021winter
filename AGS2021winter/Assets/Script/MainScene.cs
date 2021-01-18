using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public void OnClickGameButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnClickShopButton()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
