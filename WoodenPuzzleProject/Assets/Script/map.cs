﻿using System.Collections;
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

    private void Update()
    {
        if(createBaseMap == true)
        {
            BaseMap = CreateBaseMap();
            createBaseMap = false;
        }
    }

    public GameObject[,] CreateBaseMap() 
    {
        GameObject[,] spawnarray = new GameObject[width, height]; 

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {               
                GameObject cube = Instantiate(BasePrefab,new Vector3(x, 0, y), Quaternion.identity, this.transform);
                cube.GetComponent<Tile>().GridX = x;
                cube.GetComponent<Tile>().GridY = y;
                cube.name = "tile" + (y * width + x);
                spawnarray[x, y] = cube;
            }
        }

        return spawnarray;
    }
}
