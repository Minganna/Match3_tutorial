using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{

    Vector2Int posIndex;
    BoardManager board;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpGem(Vector2Int pos)
    {
        posIndex = pos;
        board = BoardManager.instance;
    }
}
