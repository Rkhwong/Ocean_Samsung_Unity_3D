using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_Aula : MonoBehaviour
{
    public Transform target;
    public float speed = 3;
    public float distance = 7;
    public float height = 0.1f;

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float time = speed * Time.deltaTime;
        Vector3 position = transform.position;

        position.x = Mathf.Lerp(
            transform.position.x,
            target.position.x,
            time);
        position.y = Mathf.Lerp(
            transform.position.y + height,
            target.position.y,
            time);
        position.z = Mathf.Lerp(
            transform.position.z,
            target.position.z - distance,
            time);

        transform.position = position;
    }
}
