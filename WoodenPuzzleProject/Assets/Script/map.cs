using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class map : MonoBehaviour
{
    [SerializeField]
    private GameObject BasePrefab;
    private GameObject[,] BaseMap;
    public int height;
    public int width;

    [SerializeField]
    private bool createBaseMap;
    [SerializeField]
    private bool destroyBaseMap;

    private void Update()
    {
        if(createBaseMap == true)
        {
            BaseMap = CreateBaseMap();
            createBaseMap = false;
        }
        if(destroyBaseMap == true)
        {
            DestroyCurrentMap();
            destroyBaseMap = false;
        }
    }

    public GameObject[,] CreateBaseMap() 
    {
        if(BaseMap == null)
        {
            GameObject[,] spawnarray = new GameObject[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    GameObject cube = Instantiate(BasePrefab, new Vector3(x, 0, y), Quaternion.identity, this.transform);
                    cube.GetComponent<Tile>().GridX = x;
                    cube.GetComponent<Tile>().GridY = y;
                    cube.name = "tile" + (y * width + x);
                    spawnarray[x, y] = cube;
                }
            }

            return spawnarray;
        }
        else
        {
            if(BaseMap.GetLength(0) != width || BaseMap.GetLength(1) != height)
            {
                DestroyCurrentMap();

                GameObject[,] spawnarray = new GameObject[width, height];

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        GameObject cube = Instantiate(BasePrefab, new Vector3(x, 0, y), Quaternion.identity, this.transform);
                        cube.GetComponent<Tile>().GridX = x;
                        cube.GetComponent<Tile>().GridY = y;
                        cube.name = "tile" + (y * width + x);
                        spawnarray[x, y] = cube;
                    }
                }

                return spawnarray;
            }

            return BaseMap;
        }
        
    }

    public void DestroyCurrentMap()
    {
        if(BaseMap != null)
        {
            foreach (var tile in BaseMap)
            {
                DestroyImmediate(tile);
            }
        }

        BaseMap = null;
    }
}
