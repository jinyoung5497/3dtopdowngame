using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  [SerializeField] internal EnemyController enemyController;
  internal bool enemyAggro = false;
  float enemyStartRange = 0.5f;


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    EnemyMovements();
  }

  private void FixedUpdate()
  {
    FreezeRotation();
  }

  void EnemyMovements()
  {
    if (enemyController.enemyAggroArea.playerEnterAggroArea || enemyAggro)
    {
      Vector3 playerDir = (enemyController.playerController.transform.position - transform.position).normalized;

      transform.position += playerDir * enemyController.enemySpeed * Time.deltaTime;

      transform.rotation = Quaternion.LookRotation(playerDir, Vector3.up);
    }
    else
    {
      if (EnemyIsAtStartPos())
      {
        Vector3 startDir = (enemyController.enemyStartPos - transform.position).normalized;

        transform.position += startDir * enemyController.enemySpeed * Time.deltaTime;

        transform.rotation = Quaternion.LookRotation(startDir, Vector3.up);
      }
    }
  }

  bool EnemyIsAtStartPos()
  {
    if (transform.position.x > enemyController.enemyStartPos.x + enemyStartRange || transform.position.x < enemyController.enemyStartPos.x - enemyStartRange)
    {
      return true;
    }
    else if (transform.position.z > enemyController.enemyStartPos.z + enemyStartRange || transform.position.z < enemyController.enemyStartPos.z - enemyStartRange)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  void FreezeRotation()
  {
    enemyController.playerController.playerRb.angularVelocity = Vector3.zero;
  }
}
