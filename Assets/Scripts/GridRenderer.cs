using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class Tile
{
    public string name;
    public int x;
    public int y;
    public bool hide;
    public int bomCount;

    public Tile(string name, int x, int y)
    {
        this.name = name;
        this.x = x;
        this.y = y;   
    }
}

public class GridRenderer : MonoBehaviour {
    
    [SerializeField, Range(0,16)] private int height;
    [SerializeField, Range(0,32)] private int width;
    [SerializeField] private GameObject tileObject, bomObject;
    private Tile[,] gameBoard;
    
    private Dictionary<Tile, GameObject> map;
    
    
    private void Awake()
    {
        map = new Dictionary<Tile, GameObject>();
        gameBoard = new Tile[width,height];
        FillArray();
        CheckBombs();
    }

    private void FillArray()
    {
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var tile = new Tile(Random.Range(0, 100) < 20 ? "Bomb" : "Tile", x, y);

                var gameObject = Instantiate(tile.name == "Bomb" ? bomObject : tileObject, new Vector2(x, y),
                    transform.rotation, transform);
                gameBoard[x, y] = tile;
                map.Add(gameBoard[x, y], gameObject);
            }
        }
    }

    private void CheckBombs()
    {
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                for (var ny = y -1; ny <= y +1; ny++)
                {
                    for (var nx = x -1; nx <= x +1; nx++)
                    {
                        if (ny > height -1 || ny < 0 || nx > width -1 || nx < 0) continue;

                        if (gameBoard[x, y].name == "Bomb") continue;

                        if (gameBoard[nx, ny].name == "Bomb")
                        {
                            gameBoard[x, y].bomCount++;
                        }
                    }
                }
            }
        }
    }
    

    public Vector2 GetWidthHeight()
    {
        return new Vector2(width, height);
    }

    public Tile[,] GetGrid()
    {
        return gameBoard;
    }
    
    public GameObject GetObject(Tile tile)
    {
        return map[tile];
    }
}
