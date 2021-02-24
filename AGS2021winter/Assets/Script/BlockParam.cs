using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockParam : MonoBehaviour
{
    [System.Serializable]
    public struct Param
    {
        public string name;
        public int score;
        public int cost;
    }
    public Param blockData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
