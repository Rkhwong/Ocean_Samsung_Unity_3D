using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private bool bouncing = true;
    public float bounceForce = 5.0f;
    private float vertical;
    private float horizontal;
    public static bool stop;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        //rb = GetComponent<Rigidbody>();
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        if (!rb || stop) return;

        Moving();
    }

    private void FixedUpdate()
    {
        if (!rb || stop) return;
        rb.AddForce(0, 0, vertical * speed, ForceMode.Force);
        rb.AddForce(horizontal * speed, 0, 0 , ForceMode.Force);
    }

    public void Moving()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
        {
            if (bouncing) return;
            rb.AddForce(0, bounceForce, 0, ForceMode.Impulse);

        }
        if (transform.position.y < -10) StartCoroutine(Reset());
    }

    private void OnCollisionStay(Collision collision)
    {
        bouncing = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        bouncing = true;
    }

    IEnumerator Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        yield return new WaitForFixedUpdate();
        transform.position = startPos;
        transform.rotation = Quaternion.identity;

    }
    public void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            // gameObject.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y , transform.position.z );
            rb.velocity = new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //gameObject.transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            rb.velocity = new Vector3(-speed, 0, 0);
        }
        if(Input.GetKey(KeyCode.W))
        {
            //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
            rb.velocity = new Vector3(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z - speed * Time.deltaTime);
            rb.velocity = new Vector3(0, 0, -speed);
        }


    }

}
