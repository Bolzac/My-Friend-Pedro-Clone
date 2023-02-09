using System;
using Managers;
using UnityEngine;
using UnityEngine.Events;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private UnityEvent onGround;
    [SerializeField] private UnityEvent onWall;
    [SerializeField] private UnityEvent onJump;

    [SerializeField] private PlayerModel playerModel;

    private void Update()
    {
        if(playerModel.health <= 0) return;
        SetCasts();
    }

    private void SetCasts()
    {
        var hit = Physics2D.Linecast(playerModel.ground.position, playerModel.ground.position + playerModel.groundDetectLenght,LayerMask.GetMask("Solid"));
        if (hit && !playerModel.isOnGround)
        {
            if (playerModel.isInAir)
            {
                playerModel.isInAir = false;
                if (playerModel.isForceApplied)
                {
                    playerModel.isForceApplied = false;
                    SoundPlayer.Instance.PlayFall();
                }
            }
            onGround.Invoke();
        }else if (!hit)
        {
            playerModel.isOnGround = false;
        }

        if(playerModel.isOnGround) return;

        hit = Physics2D.Linecast(playerModel.leftSide.position,playerModel.leftSide.position - playerModel.sideDetectLenght, LayerMask.GetMask("Solid"));

        if (hit && !playerModel.isOnWallFromLeft && !playerModel.isOnWallFromRight && !playerModel.isOnWall)
        {
            if (playerModel.isInAir)
            {
                playerModel.isInAir = false;
                if (playerModel.isForceApplied)
                {
                    playerModel.isForceApplied = false;
                    SoundPlayer.Instance.PlayWall();
                }
            }
            playerModel.isOnWallFromLeft = true;
            onWall.Invoke();
        }else if (!hit && !playerModel.isOnWallFromRight)
        {
            playerModel.isOnWallFromLeft = false;
            playerModel.onWallTime = 0;
        }

        if(playerModel.isOnWallFromLeft) return;
        
        hit = Physics2D.Linecast(playerModel.rightSide.position,playerModel.rightSide.position + playerModel.sideDetectLenght,LayerMask.GetMask("Solid"));

        if (hit && !playerModel.isOnWall && !playerModel.isOnWallFromLeft && !playerModel.isOnWallFromRight)
        {
            if (playerModel.isInAir)
            {
                playerModel.isInAir = false;
                if (playerModel.isForceApplied)
                {
                    playerModel.isForceApplied = false;
                    SoundPlayer.Instance.PlayWall();
                }
            }
            playerModel.isOnWallFromRight = true;
            onWall.Invoke();
        }else if (!hit && !playerModel.isOnWallFromLeft)
        {
            playerModel.isOnWallFromRight = false;
            playerModel.onWallTime = 0;
        }

        if (!playerModel.isOnWallFromLeft && !playerModel.isOnWallFromRight) playerModel.isOnWall = false;

        if (!playerModel.isOnGround && !playerModel.isOnWall && !playerModel.isInAir && !playerModel.isSlidingOnWall && playerModel.isForceApplied)
        {
            onJump.Invoke();
        }
    }
}
