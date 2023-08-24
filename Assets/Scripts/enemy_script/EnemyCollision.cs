using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
  [SerializeField] internal EnemyController enemyController;

  internal bool encounterPlayer;
  internal Vector3 playerPos;
  internal bool enemyTookDamage;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      encounterPlayer = true;
      playerPos = other.gameObject.transform.position;
    }
  }

  private void OnCollisionExit(Collision other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      encounterPlayer = false;
    }
  }
}
