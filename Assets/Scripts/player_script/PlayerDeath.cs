using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
  [SerializeField] internal PlayerController playerController;
  internal bool isDeath;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Death();
  }

  private void Death()
  {
    if (playerController.playerHealth <= 0 && !isDeath)
    {
      Debug.Log("DIE");
      playerController.animator.SetTrigger("playerDie");
      isDeath = true;
    }
  }
}
