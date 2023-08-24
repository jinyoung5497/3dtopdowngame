using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
  [SerializeField] internal PlayerController playerController;
  [SerializeField] internal WeaponCollision weaponCollision;
  [SerializeField] internal TrailRenderer trailRenderer;
  // Start is called before the first frame update
  void Start()
  {
    trailRenderer = GetComponent<TrailRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
  }

}
