using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //Sample blocks from where to create new blocks.
    public List<LevelBlock> legoBlocks = new List<LevelBlock>();
    // Blocks added to the game.
    List<LevelBlock> currentBlocks = new List<LevelBlock>();
    // Start is called before the first frame update

    public Transform initialPoint;

    private static LevelGenerator _sharedInstance;
    public static LevelGenerator sharedInstance
    {
        get
        {
            return _sharedInstance;
        }
    }

    private void Awake()
    {
        _sharedInstance = this;
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddNewBlock() {}
}
