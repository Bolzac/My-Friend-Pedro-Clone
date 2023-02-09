using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerModel : MonoBehaviour
{
    public int health;
    
    public new Rigidbody2D rigidbody2D;
    public Collider2D coll;
    
    public Vector2 currentPosition;
    
    public ScreenModel screenModel;

    [Header("UI")]

    #region UI

    public Sprite emptyHeart;
    public Sprite fullHeart;

    public Image[] images;

    public GameObject gameOverScreen;

    #endregion

    [Header("States")]
    #region Conditions

    public bool isOnGround;

    public bool isOnWall;

    public bool isOnWallFromLeft;
    public bool isOnWallFromRight;

    public bool isInAir;
    public bool isJumpingToLeft;
    public bool isJumpingToRight;

    public bool isForceApplied;

    public bool isSlidingOnWall;

    public bool isAscending;
    public bool isDescending;

    #endregion

    [Header("Times")]
    #region Times

    public float onWallTime;
    public float maxStayFixedTimeOnWall;

    #endregion

    [Header("GroundVariables")]
    #region GroundVariables

    public Transform ground;
    public Vector3 groundDetectLenght;

    #endregion

    [Header("SideVariables")]
    #region SideVariables

    public Transform leftSide;
    public Transform rightSide;
    public Vector3 sideDetectLenght;

    #endregion

    public RaycastHit2D Hit;

    private void Update()
    {
        if (rigidbody2D.velocity.y > 0)
        {
            if (!isAscending)
            {
                isAscending = true;
                isDescending = false;   
            }
            PlayerStateManager.PlayerManager.ChangeState(PlayerState.Ascend);
        }else if (rigidbody2D.velocity.y < 0)
        {
            if (!isDescending && isAscending)
            {
                isAscending = false;
                isDescending = true;   
            }
            if(!isSlidingOnWall) PlayerStateManager.PlayerManager.ChangeState(PlayerState.Descend);
        }
        else if(rigidbody2D.velocity.y == 0 && (isAscending || isDescending))
        {
            isDescending = false;
            isAscending = false;
            PlayerStateManager.PlayerManager.ChangeState(PlayerState.NoneAir);
        }

        if (rigidbody2D.velocity.x > 0 && !isJumpingToRight)
        {
            isJumpingToRight = true;
            transform.rotation = new Quaternion(0,0,0,0);
        }else if (rigidbody2D.velocity.x < 0 && !isJumpingToLeft)
        {
            isJumpingToLeft = true;
            transform.rotation = new Quaternion(0,180,0,0);
        }else if (rigidbody2D.velocity.x == 0)
        {
            isJumpingToLeft = false;
            isJumpingToRight = false;
        }
    }
}
