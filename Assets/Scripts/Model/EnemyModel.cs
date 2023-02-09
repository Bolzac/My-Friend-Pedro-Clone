using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyModel : MonoBehaviour
{
    public int health;
    
    public float maxTimeToFire;
    
    public float timeCounter;

    public bool isSeenPlayer;
    public bool isTimerStart;

    public RaycastHit2D Hit;

    #region View
    public Transform eye;
    #endregion
    #region Events

    public UnityEvent<bool> onCatch;

    #endregion

    
    [Header("Arm")]
    #region Arm

    public Transform arm;
    public Vector3 armDirection;
    public float armAngle;
    public float armSpeed;
    
    #endregion
}