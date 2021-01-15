using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTile : Tile
{
    [SerializeField]
    private bool isFinalTile;
    [SerializeField]
    private GameObject WinUiScreen;
    [SerializeField]
    private GameObject LoseUiScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && isFinalTile == true)
        {
            Debug.Log("WIN");
            WinUiScreen.SetActive(true);
        }
        else if(other.CompareTag("Ball") && isFinalTile == false)
        {
            Debug.Log("LOSE");
            LoseUiScreen.SetActive(true);
        }
    }
}
