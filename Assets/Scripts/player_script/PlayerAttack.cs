using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
  [SerializeField] internal PlayerController playerController;
  [SerializeField] internal GameObject Explosion;
  internal bool setAttack;
  private bool attackReady = true;
  private float attackDelay;
  private WeaponController weapon;
  private TrailRenderer trailRenderer;
  int comboNumber = 0;
  bool trailEnable;




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
        if (comboNumber == 0)
        {
          StartCoroutine(AttackPattern("isAttack", 0.5f, 0.6f));
          comboNumber++;
          return;
        }
        if (comboNumber == 1)
        {
          StartCoroutine(AttackPattern("combo1", 0.5f, 0.51f));
          comboNumber++;
          return;
        }
        if (comboNumber == 2)
        {
          StartCoroutine(AttackPattern("combo2", 0.5f, 0.51f));
          comboNumber++;
          return;
        }
        if (comboNumber == 3)
        {
          trailEnable = true;
          StartCoroutine(AttackPattern("combo3", 0.5f, 0.51f));
          comboNumber = 0;
          return;
        }

      }
    }
  }

  IEnumerator AttackPattern(string patternName, float animDelay, float trigDuration)
  {
    trailRenderer = playerController.weapons[playerController.weaponIndex].GetComponentInChildren<TrailRenderer>();
    trailRenderer.enabled = true;
    attackReady = false;
    playerController.animator.SetTrigger(patternName);
    setAttack = true;
    yield return new WaitForSeconds(animDelay);
    playerController.playerAttackTrigger.enabled = true;
    if (trailEnable)
    {
      Explosion.SetActive(true);
    }
    yield return new WaitForSeconds(trigDuration);
    playerController.playerAttackTrigger.enabled = false;
    Explosion.SetActive(false);
    trailRenderer.enabled = false;
    setAttack = false;
    attackReady = true;
    trailEnable = false;
  }


  //* Player attack and knock back and damage enemy
  void KnockBackEnemy()
  {
    if (playerController.playerCollision.isPlayerInRange)
    {
      //* Enemy Knock Back
      Vector3 enemyknockBackDir = playerController.playerCollision.nearEnemy.transform.position - transform.position;

      playerController.playerCollision.nearEnemy.enemyRb.AddForce(enemyknockBackDir * 1000f * Time.fixedDeltaTime, ForceMode.Impulse);

      //* Get weapon and calculate damage
      WeaponController weapon = playerController.weapons[playerController.weaponIndex].GetComponent<WeaponController>();

      playerController.playerCollision.nearEnemy.EnemyHealth -= weapon.weaponCollision.weaponDamage;

      Debug.Log("Enemy Damaged " + playerController.playerCollision.nearEnemy.enemyHealth);

      playerController.playerCollision.isPlayerInRange = false;
    }
  }
}

