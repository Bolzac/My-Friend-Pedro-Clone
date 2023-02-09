using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyModel enemyModel;
    [SerializeField] private PlayerModel playerModel;

    [SerializeField] private UnityEvent attack;

    private void Update()
    {
        enemyModel.isTimerStart = enemyModel.isSeenPlayer;
        if (enemyModel.isTimerStart && enemyModel.isSeenPlayer)
        {
            //Arm Rotation
            PointGun(true);
            //Counter
            enemyModel.timeCounter += Time.deltaTime;
            if (enemyModel.timeCounter >= enemyModel.maxTimeToFire)
            {
                Attack();
            }
        }
        else
        {
            PointGun(false);
            enemyModel.timeCounter = 0;
        }
    }

    public void GetDamage()
    { 
        enemyModel.health -= 1;
        if(enemyModel.health <= 0) Die();
    } 

    private void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
    }

    private void Attack()
    {
        SoundPlayer.Instance.PlayShot();
        attack.Invoke();
        enemyModel.timeCounter = 0;
    }

    private void PointGun(bool player)
    {
        if (player)
        {
            enemyModel.armDirection = ((Vector3)playerModel.currentPosition - transform.position).normalized;
            enemyModel.armAngle = Mathf.Atan2(enemyModel.armDirection.y, enemyModel.armDirection.x) * Mathf.Rad2Deg;
            enemyModel.arm.rotation = Quaternion.Euler(0, 0, enemyModel.armAngle);
        }
        else enemyModel.arm.rotation = Quaternion.Euler(0,0,-90);
    }
}