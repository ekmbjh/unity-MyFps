using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestt : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float sideSpeed = 100f;

    private Rigidbody rb;
    public float forwardForce = 500f;
    public float sideForce = 400f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float Horizontal = Input.GetAxis("Horizontal");

        //Vector3 Position = transform.position;

        //Position.x = Horizontal * Time.deltaTime * sideSpeed;

        //transform.position = Position;

        // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        float dx = Input.GetAxis("Horizontal");
        if (dx < 0)
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0);
        }
        if (dx > 0)
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0);
        }
    }
}
