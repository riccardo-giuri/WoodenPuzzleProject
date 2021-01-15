﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
    }

    public void ActiveUI(GameObject ToActive, GameObject ToDeactive)
    {
        ToDeactive.SetActive(false);
        ToActive.SetActive(true);
    }

}
