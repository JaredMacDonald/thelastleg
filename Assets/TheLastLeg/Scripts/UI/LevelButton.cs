﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [HideInInspector]
    public int LevelIndex;
	public void OnClick()
    {
        MenuManager.Instance.LoadLevel(LevelIndex);
    }
}
