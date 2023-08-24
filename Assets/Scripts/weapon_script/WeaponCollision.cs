using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
  [SerializeField] internal WeaponController weaponController;
  public BoxCollider weaponCollider;
  private EnemyController enemyController;
  [SerializeField] internal float weaponAttackRate;
  [SerializeField] internal float weaponDamage;

  // Start is called before the first frame update
  void Awake()
  {
    weaponCollider = GetComponent<BoxCollider>();
  }

  // Update is called once per frame
  void Update()
  {
    EnableBoxCollider();
  }
  void EnableBoxCollider()
  {
    // if (weaponController.playerController.playerAttack.setAttack)
    // {
    //   weaponCollider.enabled = true;
    // }
    // else
    // {
    //   weaponCollider.enabled = false;
    // }
  }

  public void OnTriggerEnter(Collider other)
  {
    // if (other.gameObject.CompareTag("Enemy"))
    // {
    //   enemyController = other.GetComponent<EnemyController>();
    //   enemyController.enemyHealth -= weaponDamage;
    //   Debug.Log("hit" + weaponDamage);
    // }
  }

}
