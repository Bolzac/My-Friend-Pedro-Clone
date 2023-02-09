using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerModel playerModel;

    private void Start()
    {
        foreach (var t in playerModel.images)
        {
            t.sprite = playerModel.fullHeart;
        }
    }

    private void Update()
    {
        playerModel.currentPosition = transform.position;
        if(playerModel.isOnWall) CheckWallTime();
    }

    public void Jump(Vector2 force)
    {
        PlayerStateManager.PlayerManager.ChangeState(PlayerState.Air);
        playerModel.isForceApplied = true;
        playerModel.rigidbody2D.gravityScale = 1;
        playerModel.screenModel.isMouseHeldDown = false;
        playerModel.rigidbody2D.AddForce(force,ForceMode2D.Impulse);
        SoundPlayer.Instance.PlayJump();
    }

    public void SetOnGround()
    {
        playerModel.isOnGround = true;
        playerModel.isOnWall = false;
        playerModel.isOnWallFromRight = false;
        playerModel.isOnWallFromLeft = false;
        playerModel.isSlidingOnWall = false;
        if(!playerModel.isForceApplied) playerModel.rigidbody2D.velocity = Vector2.zero;
        PlayerStateManager.PlayerManager.ChangeState(PlayerState.Ground);
    }

    public void SetOnWall()
    {
        if (!playerModel.isOnWall)
        {
            playerModel.isOnWall = true;
            playerModel.isOnGround = false;
        }
        if (!playerModel.isForceApplied && !playerModel.isSlidingOnWall)
        {
            playerModel.rigidbody2D.velocity = Vector2.zero;
            playerModel.rigidbody2D.gravityScale = 0;
        }
        PlayerStateManager.PlayerManager.ChangeState(PlayerState.Wall);
    }

    public void SetJump()
    {
        playerModel.isInAir = true;
        if (playerModel.isSlidingOnWall)
        {
            playerModel.isSlidingOnWall = false;
            playerModel.onWallTime = 0;
        }
        playerModel.rigidbody2D.gravityScale = 1;
    }

    private IEnumerator SlideOnWall()
    {
        PlayerStateManager.PlayerManager.ChangeState(PlayerState.Slide);
        for (int i = 0; i < 15; i++)
        {
            playerModel.rigidbody2D.gravityScale += 0.02f;
            yield return null;
        }
    }

    private void CheckWallTime()
    { 
        playerModel.onWallTime += Time.deltaTime;
        if (playerModel.onWallTime > playerModel.maxStayFixedTimeOnWall && !playerModel.isSlidingOnWall)
        {
            playerModel.isSlidingOnWall = true;
            StartCoroutine(SlideOnWall());
        }
    }

    public void FireGun()
    {
        if (playerModel.screenModel.isClickedOnLeft && !playerModel.screenModel.isClickedOnRight)
        {
            StartCoroutine(CreateFireRay(playerModel.leftSide.position));
        }else if (playerModel.screenModel.isClickedOnRight && !playerModel.screenModel.isClickedOnLeft)
        {
            StartCoroutine(CreateFireRay(playerModel.rightSide.position));
        }
        if (playerModel.Hit.transform.CompareTag("Enemy"))
        {
                playerModel.Hit.transform.GetComponent<EnemyController>().GetDamage();
        }
        
        SoundPlayer.Instance.PlayShot();
    }

    private IEnumerator CreateFireRay(Vector2 position)
    {
        playerModel.Hit = Physics2D.Raycast(position,
            (playerModel.screenModel.clickPosition - position).normalized,
            Mathf.Infinity,
            LayerMask.GetMask("Enemy","Solid"));
        
        Debug.DrawRay(position,
            (playerModel.screenModel.clickPosition -position),Color.green);
        yield return new WaitForSeconds(0.03f);
    }

    public void TakeDamage()
    {
        playerModel.health -= 1;
        playerModel.images[playerModel.health].sprite = playerModel.emptyHeart;
        if (playerModel.health <= 0)
        {
            playerModel.gameOverScreen.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        GameManager.Instance.RetryScene();
    }

    public void ExitGameplay()
    {
        GameManager.Instance.BackMenu();
    }
}