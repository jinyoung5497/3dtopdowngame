using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
  [SerializeField] internal PlayerController playerController;
  internal bool setAttack;
  private bool attackReady = true;
  private float attackDelay;
  private WeaponController weapon;

  // Start is called before the first frame update
  void Awake()
  {
    weapon = playerController.weapons[playerController.weaponIndex].GetComponent<WeaponController>();
  }

  // Update is called once per frame
  void Update()
  {
    Attack();
    KnockBackEnemy();
  }
  void Attack()
  {
    if (playerController.playerMovement.isGround && playerController.playerInput.isAttack && playerController.hasWeapon)
    {
      if (attackReady)
      {
        StartCoroutine("HoldAttack");
      }
    }
  }

  IEnumerator HoldAttack()
  {
    attackReady = false;
    playerController.animator.SetTrigger("isAttack");
    setAttack = true;
    yield return new WaitForSeconds(0.5f);
    playerController.playerAttackTrigger.enabled = true;
    playerController.trailRenderer.enabled = true;
    yield return new WaitForSeconds(0.6f);
    playerController.playerAttackTrigger.enabled = false;
    playerController.trailRenderer.enabled = false;
    setAttack = false;
    attackReady = true;
  }
  //* Player attack and knock back and damage enemy
  void KnockBackEnemy()
  {
    if (playerController.playerCollision.isPlayerInRange)
    {
      //* Enemy Knock Back
      Vector3 enemyknockBackDir = playerController.playerCollision.nearEnemy.transform.position - transform.position;

      playerController.playerCollision.nearEnemy.enemyRb.AddForce(enemyknockBackDir * 500f * Time.fixedDeltaTime, ForceMode.Impulse);

      //* Get weapon and calculate damage
      WeaponController weapon = playerController.weapons[playerController.weaponIndex].GetComponent<WeaponController>();

      playerController.playerCollision.nearEnemy.EnemyHealth -= weapon.weaponCollision.weaponDamage;

      Debug.Log("Enemy Damaged " + playerController.playerCollision.nearEnemy.enemyHealth);

      playerController.playerCollision.isPlayerInRange = false;
    }
  }
}

