using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
  [SerializeField] internal EnemyController enemyController;
  [SerializeField] private float enemyAttackRange = 6f;
  private bool enemyCanAttack;
  // private bool playerCanAttack;


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    EnemyAttacks();
    EnemyAttackRange();
  }

  void EnemyAttacks()
  {
    //* If enemy hits player and player isn't invincible
    //* knock back player and damage player
    if (enemyController.enemyCollision.encounterPlayer && !enemyController.playerController.playerMovement.isPlayerInvincible)
    {
      Vector3 pushPlayer = enemyController.enemyCollision.playerPos - transform.position;
      enemyController.playerController.playerRb.AddForce(pushPlayer * 15000f * Time.fixedDeltaTime, ForceMode.Impulse);
      enemyController.enemyAttackDelay = 0;
      //* enemy can only damage player once at a time
      enemyCanAttack = true;
      if (enemyCanAttack)
      {
        enemyController.playerController.playerHealth -= enemyController.enemyDamage;
        enemyCanAttack = false;
      }
    }
  }

  void EnemyAttackRange()
  {
    if (transform.position.x > enemyController.enemyStartPos.x + enemyAttackRange || transform.position.x < enemyController.enemyStartPos.x + -enemyAttackRange)
    {
      enemyController.enemyMovement.enemyAggro = false;
    }
    if (transform.position.z > enemyController.enemyStartPos.z + enemyAttackRange || transform.position.z < enemyController.enemyStartPos.z + -enemyAttackRange)
    {
      enemyController.enemyMovement.enemyAggro = false;
    }
  }
}
