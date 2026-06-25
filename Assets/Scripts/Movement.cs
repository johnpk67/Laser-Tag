using Mirror;
using System.Runtime.InteropServices;
using UnityEngine;

public class Movement : NetworkBehaviour
{
    Rigidbody rb;
    private Vector3 vel;
    private int speed = 10;
    private float yrot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //yrot = Input.GetAxis("Mouse X");
        //transform.eulerAngles = new Vector3(0f,yrot,0f);
        //vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        //}
        //rb.linearVelocity = vel * speed;
    }
}
