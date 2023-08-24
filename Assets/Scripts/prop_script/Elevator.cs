using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
  private bool isElevating = false;
  private Vector3 startPos;
  private float elevationSpeed = 2f;

  // Start is called before the first frame update
  void Start()
  {
    startPos = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    Elevate();
  }

  void Elevate()
  {
    if (isElevating)
    {
      transform.position += new Vector3(0, elevationSpeed * Time.deltaTime);
    }
    else
    {
      transform.position += (startPos - transform.position) * 1f * Time.deltaTime;
    }
  }

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      isElevating = true;
    }
  }

  private void OnCollisionExit(Collision other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      isElevating = false;
    }
  }
}
