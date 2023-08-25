using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyController : MonoBehaviour
{
  [SerializeField] internal PlayerController playerController;
  [SerializeField] internal EnemyMovement enemyMovement;
  [SerializeField] internal EnemyAttack enemyAttack;
  [SerializeField] internal EnemyDeath enemyDeath;
  [SerializeField] internal EnemyCollision enemyCollision;
  [SerializeField] internal EnemyAggroArea enemyAggroArea;

  [SerializeField] internal float enemySpeed;
  [SerializeField] internal float enemyDamage;
  [SerializeField] internal float enemyHealth;
  [SerializeField] internal float EnemyHealth { get { return enemyHealth; } set { enemyHealth = value; } }
  [SerializeField] internal float enemyAttackRate;
  [SerializeField] internal float enemyAttackDelay;
  [SerializeField] internal bool isEnemyAttackReady;

  internal Vector3 enemyStartPos;
  internal Quaternion enemyStartRotation;

  internal Animator animator;
  internal Rigidbody enemyRb;



  // Start is called before the first frame update
  void Awake()
  {
    animator = GetComponentInChildren<Animator>();
    enemyRb = GetComponent<Rigidbody>();
    enemyStartPos = transform.position;
    enemyStartRotation = transform.rotation;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
