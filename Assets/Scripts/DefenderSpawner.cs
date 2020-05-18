﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defenderType;
    private void OnMouseDown()
    {
        SpawnDefender(GetMouseClickPosition());
    }

    private Vector2 GetMouseClickPosition()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    private void SpawnDefender(Vector2 worldPos)
    {

        GameObject newDefender = Instantiate(defenderType,
            worldPos, 
            Quaternion.identity) as GameObject;
    }
}
