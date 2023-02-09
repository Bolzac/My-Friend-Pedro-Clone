using System;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private EnemyModel enemyModel;
    [SerializeField] private PlayerModel playerModel;
    private void Update()
    {
        if(playerModel.health <= 0) return;
        CreateVision();
    }

    private void CreateVision()
    {
        enemyModel.Hit = Physics2D.Linecast(enemyModel.eye.position,
            playerModel.currentPosition,
                LayerMask.GetMask("Solid", "Player"));

        if (enemyModel.Hit.transform.CompareTag("Player"))
        {
            enemyModel.isSeenPlayer = true;
            enemyModel.onCatch.Invoke(enemyModel.isSeenPlayer);
        }
        else
        {
            enemyModel.isSeenPlayer = false;
            enemyModel.onCatch.Invoke(enemyModel.isSeenPlayer);
        }
        Test();
    }

    private void Test()
    {
        Debug.DrawLine(enemyModel.eye.position, playerModel.currentPosition,
            enemyModel.isSeenPlayer ? Color.red : Color.white);
    }
}