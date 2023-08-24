using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroArea : MonoBehaviour
{
  [SerializeField] internal EnemyController enemyController;
  internal bool playerEnterAggroArea;

  // Start is called before the first frame update
  void Awake()
  {

  }

  // Update is called once per frame
  void Update()
  {
    StayInStartPos();
  }

  void StayInStartPos()
  {
    transform.position = enemyController.enemyStartPos;
    transform.rotation = enemyController.enemyStartRotation;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      playerEnterAggroArea = true;
      enemyController.enemyMovement.enemyAggro = true;
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      playerEnterAggroArea = false;
    }
  }
}
