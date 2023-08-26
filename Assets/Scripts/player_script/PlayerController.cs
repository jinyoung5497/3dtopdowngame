using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{

  [SerializeField] internal PlayerInput playerInput;
  [SerializeField] internal PlayerMovement playerMovement;
  [SerializeField] internal PlayerAttack playerAttack;
  [SerializeField] internal PlayerInteraction playerInteraction;
  [SerializeField] internal PlayerDeath playerDeath;
  [SerializeField] internal PlayerCollision playerCollision;
  [SerializeField] internal float playerHealth;
  [SerializeField] internal List<GameObject> weapons;
  internal int weaponIndex = 0;
  internal bool hasWeapon = false;

  internal TrailRenderer trailRenderer;
  internal SphereCollider playerAttackTrigger;
  internal Rigidbody playerRb;
  internal Animator animator;

  /** 
    1. Environment terrain
    box prototype
    tutorial map

    Backpack
    attack various animation
    Dash
    player smooth rotation
    potion
    level 1
    Respawn point
*/

  // Start is called before the first frame update
  void Awake()
  {
    playerRb = GetComponent<Rigidbody>();
    animator = GetComponent<Animator>();
    playerAttackTrigger = GetComponent<SphereCollider>();
    trailRenderer = weapons[weaponIndex].GetComponent<TrailRenderer>();
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  // Update is called once per frame
  void Update()
  {
  }
}
