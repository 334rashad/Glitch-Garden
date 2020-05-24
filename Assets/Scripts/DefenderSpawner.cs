using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderType;
    private void OnMouseDown()
    {
        PlaceDefenderAt(GetMouseClickPosition());
    }

    public void SetDefender(Defender selected)
    {
        defenderType = selected;
    }

    private void PlaceDefenderAt(Vector2 gridPos)
    {
        var coinsDisplay = FindObjectOfType<CoinsDisplay>();
        int defenderCost = defenderType.GetCoinCost();
        if(coinsDisplay.HaveEnoughCoins(defenderCost))
        {
            SpawnDefender(gridPos);
            coinsDisplay.SpendCoins(defenderCost);
        }
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
        Defender newDefender = Instantiate(defenderType,
            roundedPos, 
            Quaternion.identity) as Defender;
    }
}
