using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out Rigidbody rb);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Movement.stop = true;

    }


}
