﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventorySystem : MonoBehaviour
{
   public enum BlockID
    {
        dirt,
        stone,
        gem,
        max
    }
    int[] inventory;
    [SerializeField][Header("重量")]
    public int maxCost;
    private int nowCost;
    private int score;
    private bool finFlag;
    private GameObject newObj;
    private Dictionary<string, int> stackCnt = new Dictionary<string,int>();
    // Start is called before the first frame update
    void Start()
    {
        finFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddInventory(GameObject obj)
    {
        var block = obj.GetComponent<BlockParam>();
        if(block == null)
        {
            return;
        }
        if(!isCarry(block.blockData.cost)&& block.blockData.name != "Treasure")
        {
            return;
        }
        nowCost += block.blockData.cost;
        score += block.blockData.score;
        if(stackCnt.ContainsKey(block.blockData.name))
        {
            stackCnt[block.blockData.name]++;
        }
        else
        {
            stackCnt.Add(block.blockData.name,1);
        }
        if(block.blockData.name == "gem")
        {
            finFlag = true;
        }
        Debug.Log(stackCnt[block.blockData.name]);
    }
    public bool isFin()
    {
        return finFlag;
    }
    public int GetScore()
    {
        return score;
    }
    public void Init()
    {
        List<string> keyList = new List<string>(stackCnt.Keys);
        foreach(var key in keyList)
        {
            stackCnt[key] = 0;
        }
        nowCost = 0;
        score = 0;
    }
    public int GetNowCost()
    {
        return nowCost;
    }
    public bool isCarry(int cost)
    {
        return (maxCost > nowCost+cost);
    }
}
