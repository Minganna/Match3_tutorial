using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{

    Vector2Int posIndex;
    BoardManager board;

    private Vector2 firstTouchPos;
    private Vector2 finalTouchPos;

    private bool mousePressed;
    private float swipeAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mousePressed && Input.GetMouseButtonUp(0))
        {
            mousePressed = false;
            finalTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            calculateAngle();
        }

    }

    public void SetUpGem(Vector2Int pos)
    {
        posIndex = pos;
        board = BoardManager.instance;
    }

    private void OnMouseDown()
    {
        firstTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePressed = true;
    }

    private void calculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPos.y - firstTouchPos.y, finalTouchPos.x - firstTouchPos.x);
        swipeAngle = swipeAngle * 180 / Mathf.PI;
        print(swipeAngle);
    }
}
