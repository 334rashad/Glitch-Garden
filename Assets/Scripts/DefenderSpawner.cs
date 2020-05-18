using System.Collections;
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
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float posX = Mathf.RoundToInt(rawWorldPos.x);
        float posY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(posX, posY);
    }


    private void SpawnDefender(Vector2 roundedPos)
    {
        GameObject newDefender = Instantiate(defenderType,
            roundedPos, 
            Quaternion.identity) as GameObject;
    }
}
