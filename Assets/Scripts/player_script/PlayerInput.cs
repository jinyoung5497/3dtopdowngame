using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  [SerializeField] internal PlayerController playerController;

  internal bool isJump;
  internal bool isInteract;
  internal bool isAttack;

  // Update is called once per frame
  void Update()
  {
    GetInput();
  }

  internal void GetInput()
  {
    isJump = Input.GetButtonDown("Jump");
    isInteract = Input.GetButtonDown("Interact");
    isAttack = Input.GetButtonDown("Fire1");
  }
}
