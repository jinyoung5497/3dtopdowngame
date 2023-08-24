using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  [SerializeField] internal PlayerController playerController;
  internal Vector3 ladderPos;
  internal GameObject nearObject;
  internal EnemyController nearEnemy;
  internal bool playerKnockBack;
  internal bool isPlayerInRange = false;
  internal bool enemyEncounter;

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      playerController.playerMovement.isGround = true;
      playerController.animator.SetBool("isJump", false);
    }
    if (collision.gameObject.CompareTag("Enemy"))
    {
      enemyEncounter = true;

      if (!playerController.playerMovement.isPlayerInvincible)
      {
        playerKnockBack = true;
      }
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Weapon"))
    {
      nearObject = other.gameObject;
    }
    if (other.gameObject.CompareTag("Enemy"))
    {
      isPlayerInRange = true;
      nearEnemy = other.gameObject.GetComponent<EnemyController>();
    }
    if (other.gameObject.CompareTag("Ladder"))
    {
      playerController.playerMovement.isClimbing = true;
    }
  }

  private void OnTriggerStay(Collider other)
  {
    if (other.gameObject.CompareTag("Weapon"))
    {
      nearObject = other.gameObject;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    nearObject = null;
    if (other.gameObject.CompareTag("Enemy"))
    {
      isPlayerInRange = false;
      nearEnemy = null;
    }
    if (other.gameObject.CompareTag("Ladder"))
    {
      playerController.playerMovement.isClimbing = false;
      ladderPos = other.transform.position;
    }
  }
}
