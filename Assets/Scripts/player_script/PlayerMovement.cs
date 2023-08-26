using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] internal PlayerController playerController;
  [SerializeField] private float jumpForce = 20f;
  internal bool isGround;
  internal bool isClimbing;
  private float moveSpeed = 5f;
  private float horizontalInput;
  private float verticalInput;
  private bool isWall;
  private Vector3 playerPosition;
  private Vector3 jumpVector;
  private float playerStunStartDuration = 0f;
  private float playerStunEndDuration = 0.5f;
  private bool isPlayerStunned;
  private float playerInvincibleStartDuration = 0f;
  private float playerInvincibleEndDuration = 2f;
  private bool isPlayerInvincibleDuration;
  internal bool isPlayerInvincible;
  private bool isDashing;

  void Update()
  {
    Movement();
    Rotation();
    JumpAnimation();
    Jump();
    Dash();
    JumpGravityMultiplier();
  }

  private void FixedUpdate()
  {
    FreezeRotation();
    WallProtection();
  }

  void Movement()
  {
    horizontalInput = Input.GetAxisRaw("Horizontal");
    verticalInput = Input.GetAxisRaw("Vertical");

    //* Stop moving when attacking or dying
    if (playerController.playerAttack.setAttack || playerController.playerDeath.isDeath)
    {
      horizontalInput = 0;
      verticalInput = 0;
    }

    StunDuration();
    InvincibleDuration();

    //* Player move direction
    playerPosition = new Vector3(horizontalInput, 0, verticalInput).normalized;

    //* Player is moving: isRun is true / Player stopped: isRun is false
    if (playerPosition != Vector3.zero)
    {
      playerController.animator.SetBool("isRun", true);
      // playerController.playerRb.mass = 1;
    }
    else
    {
      playerController.animator.SetBool("isRun", false);
      // playerController.playerRb.mass = 2;
    }

    //* Player Movement Input unless it hits the wall
    if (!isWall)
    {
      // transform.position += (isGround ? playerPosition : jumpVector) * moveSpeed * Time.deltaTime;
      transform.position += playerPosition * moveSpeed * Time.deltaTime;
    }
  }

  void StunDuration()
  {
    //* Stop moving when player is knocked back by enemy during stunduration.
    if (playerController.playerCollision.playerKnockBack)
    {
      horizontalInput = 0;
      verticalInput = 0;
      //* Start stun duration
      playerStunStartDuration += Time.deltaTime;
      isPlayerStunned = playerStunStartDuration > playerStunEndDuration;

      //* player is stunned
      if (isPlayerStunned)
      {
        playerStunStartDuration = 0f;
        playerController.playerCollision.playerKnockBack = false;
      }
    }
  }

  void InvincibleDuration()
  {
    //* Player is invincible until invincible duration
    if (playerController.playerCollision.enemyEncounter)
    {
      isPlayerInvincible = true;
      //* Start Invincible duration
      playerInvincibleStartDuration += Time.deltaTime;
      isPlayerInvincibleDuration = playerInvincibleStartDuration > playerInvincibleEndDuration;

      //* player is invincible reset
      if (isPlayerInvincibleDuration)
      {
        isPlayerInvincible = false;
        playerController.playerCollision.playerKnockBack = false;
        playerInvincibleStartDuration = 0f;
        playerController.playerCollision.enemyEncounter = false;

      }
    }
  }

  void Rotation()
  {
    // if (isGround && playerPosition != Vector3.zero && !playerController.playerDeath.isDeath && !isClimbing)
    // {
    //   transform.LookAt(playerPosition + transform.position);
    // }
    if (playerPosition != Vector3.zero && !playerController.playerDeath.isDeath && !isClimbing)
    {
      transform.LookAt(playerPosition + transform.position);
    }
  }

  //* Player freeze Rotation
  void FreezeRotation()
  {
    playerController.playerRb.angularVelocity = Vector3.zero;
  }

  //* Player fire raycast to detect walls
  void WallProtection()
  {
    isWall = Physics.Raycast(transform.position, transform.forward, 0.8f, LayerMask.GetMask("Wall"));
    isWall = Physics.Raycast(transform.position, (transform.forward + transform.right).normalized, 0.5f, LayerMask.GetMask("Wall"));
    isWall = Physics.Raycast(transform.position, (transform.forward - transform.right).normalized, 0.5f, LayerMask.GetMask("Wall"));
  }

  void Jump()
  {
    //* Player Jump
    if (playerController.playerInput.isJump && isGround)
    {
      playerController.playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      jumpVector = playerPosition;
      isGround = false;
    }
  }

  void JumpGravityMultiplier()
  {
    if (!isGround)
    {
      playerController.playerRb.mass += Time.deltaTime * 10000f;
    }
    else
    {
      playerController.playerRb.mass = 1;
    }
  }

  void JumpAnimation()
  {
    //* Player Jump Animation
    if (playerController.playerInput.isJump && isGround)
    {
      playerController.animator.SetBool("isJump", true);
      playerController.animator.SetBool("isRun", false);
    }
  }

  void Dash()
  {
    if (playerController.playerInput.isDash && isGround && !playerController.playerAttack.setAttack && !isDashing)
    {
      StartCoroutine("DashDuration");
    }
  }

  IEnumerator DashDuration()
  {
    isDashing = true;
    playerController.animator.SetTrigger("isRoll");
    Vector3 dashDir = new Vector3(horizontalInput, 0, verticalInput).normalized;
    playerController.playerRb.AddForce(dashDir * 5000f);
    yield return new WaitForSeconds(0.7f);
    isDashing = false;
  }
}
