using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int gridHeight, gridWidth;

    [SerializeField]
    private Tile tilePrefab;

    [SerializeField]
    Transform parent;

    [SerializeField]
    private Sprite[] sprites;

    private void Awake()
    {
        GenerateGrid();
        childrenNaming();
    }

    void GenerateGrid() 
    {
        Tile spawnedTile = null;
        for (int x = 0; x < gridWidth; x++)
        {
            Debug.Log(x);
            for (int y = 0; y < gridHeight; y++)
            {
                Debug.Log(y);
                spawnedTile = Instantiate(tilePrefab, new Vector3(x,y), Quaternion.identity, parent);
            }
        }
    }

    void childrenNaming()
    {

        int count = parent.childCount;

        for (int i = 0; i < count; i++)
        {
            parent.GetChild(i).gameObject.name = "" + i;
        }
        
    }
}
