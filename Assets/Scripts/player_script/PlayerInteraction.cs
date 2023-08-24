using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
  [SerializeField] internal PlayerController playerController;


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Interaction();
  }

  private void Interaction()
  {
    if (playerController.playerInput.isInteract && playerController.playerCollision.nearObject)
    {
      if (playerController.playerCollision.nearObject.tag == "Weapon")
      {
        Destroy(playerController.playerCollision.nearObject);
        playerController.hasWeapon = true;
        playerController.weaponIndex++;
        playerController.weapons[playerController.weaponIndex].SetActive(true);
        playerController.weapons[playerController.weaponIndex - 1].SetActive(false);
      }
      else
      {
        return;
      }
    }
  }
}
