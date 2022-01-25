using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public int Width;
    public int height;

    public GameObject bgTilePrefab;

    public static BoardManager instance;

    [SerializeField]
    List<Gems> gems;

    // 2D array used to keep track of the Gems positions
    Gems[,] allGems;
    // Start is called before the first frame update
    void Start()
    {
        allGems = new Gems[Width, height];
        instance = this;
        SetUp();
    }
     
    private void SetUp()
    {
        for(int x=0; x < Width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 pos = new Vector2(x, y);
                
                SpawnBoardPiece(x, y, pos);
                SpawnGem(new Vector2(x,y));
            }
        }
    }

    private void SpawnBoardPiece(int x, int y, Vector2 pos)
    {
        GameObject bgTile = Instantiate(bgTilePrefab);
        bgTile.transform.parent = this.transform;
        bgTile.transform.localPosition = Vector3.zero;
        bgTile.transform.localPosition = pos;
        bgTile.transform.rotation = Quaternion.identity;
        bgTile.name = "BG Tile - " + x + "," + y;
    }

    private void SpawnGem(Vector2 pos)
    {
        int gemToUse = Random.Range(0, gems.Count);
        Gems gem = Instantiate(gems[gemToUse]);
        gem.transform.parent = this.transform;
        gem.transform.localPosition = Vector3.zero;
        gem.transform.localPosition = pos;
        gem.transform.rotation = Quaternion.identity;
        gem.name="Gem - " + pos.x + "," + pos.y;
        allGems[(int)pos.x, (int)pos.y] = gem;
        gem.SetUpGem(new Vector2Int((int)pos.x, (int)pos.y));
    }
}
