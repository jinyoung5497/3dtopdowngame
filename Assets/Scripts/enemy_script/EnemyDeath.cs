using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
  [SerializeField] internal EnemyController enemyController;


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    EnemyDeaths();
  }

  void EnemyDeaths()
  {
    if (enemyController.enemyHealth <= 0)
    {
      Debug.Log("Enemy Death");
      Destroy(gameObject);
    }
  }
}
