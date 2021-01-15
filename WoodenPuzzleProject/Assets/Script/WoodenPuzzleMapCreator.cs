using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WoodenPuzzleMapCreator : map
{
    [SerializeField]
    private GameObject WallTilePrefab;
    [SerializeField]
    private GameObject HoleTilePrefab;
    [SerializeField]
    private GameObject FloorTilePrefab;

    private Dictionary<Color, GameObject> colorTileDictionary = new Dictionary<Color, GameObject>();

    [SerializeField]
    private bool BuildLevel;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (createBaseMap == true)
        {
            BaseMap = CreateBaseMap();
            createBaseMap = false;
        }
        if (destroyBaseMap == true)
        {
            DestroyCurrentMap();
            destroyBaseMap = false;
        }
        if (dictionaryCheckForNull() == true)
        {
            colorTileDictionary.Clear();
            colorTileDictionary.Add(Color.red, HoleTilePrefab);
            colorTileDictionary.Add(Color.black, WallTilePrefab);
            colorTileDictionary.Add(Color.white, FloorTilePrefab);
        }
        if (BuildLevel == true)
        {
            BuildLevelWithColorMap();
            BuildLevel = false;
        }
    }

    //void BuildLevelWithColorMap()
    //{
    //    if(BaseMap != null)
    //    {
    //        foreach (var tile in BaseMap)
    //        {
    //            Color tileColor = tile.GetComponent<Renderer>().sharedMaterial.color;
    //            if (colorTileDictionary.ContainsKey(tileColor))
    //            {
    //                Vector3 tilepos = new Vector3(tile.transform.position.x, colorTileDictionary[tileColor].transform.position.y, tile.transform.position.z);
    //                int gridPosX = tile.GetComponent<Tile>().GridX;
    //                int gridPosY = tile.GetComponent<Tile>().GridY;
    //                DestroyImmediate(tile);
    //                GameObject Newtile = Instantiate(colorTileDictionary[tileColor], tilepos, Quaternion.identity, this.transform);
    //                BaseMap[gridPosX, gridPosY] = Newtile;
    //            }
    //            else
    //            {
    //                Debug.LogError("some tile has wrong color");
    //            }
    //        }
    //    }
    //}

    void BuildLevelWithColorMap()
    {
        if (BaseMap != null)
        {
            for (int y = 0; y < BaseMap.GetLength(1); y++)
            {
                for (int x = 0; x < BaseMap.GetLength(0); x++)
                {
                    Color tileColor = BaseMap[x, y].GetComponent<Renderer>().sharedMaterial.color;
                    if ((colorTileDictionary.ContainsKey(tileColor)))
                    {
                        Vector3 tilepos = new Vector3(BaseMap[x, y].transform.position.x, colorTileDictionary[tileColor].transform.position.y, BaseMap[x, y].transform.position.z);
                        DestroyImmediate(BaseMap[x, y]);
                        GameObject Newtile = Instantiate(colorTileDictionary[tileColor], tilepos, Quaternion.identity, this.transform);
                        BaseMap[x, y] = Newtile;
                    }
                }
            }
        }
    }

    bool dictionaryCheckForNull()
    {
        if (colorTileDictionary.Count == 0)
        {
            return true;
        }
        else
        {
            foreach (KeyValuePair<Color, GameObject> item in colorTileDictionary)
            {
                if (item.Value == null)
                {
                    return true;
                }
            }
        }

        return false;
    }

    //void CreateWallAround(GameObject[,] grid)
    //{
    //    grid[0,]
    //}
}