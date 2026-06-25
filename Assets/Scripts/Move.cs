using Mirror;
using UnityEngine;

public class Move : NetworkBehaviour
{
    Rigidbody rb;
    private float yrot;
    public bool canjump;
    private Transform trans;

    private float v;
    private float h;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canjump = true;
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            yrot += Input.GetAxis("Mouse X") * 10;
            trans.rotation = Quaternion.Euler(0, yrot, 0);

            v = Input.GetAxis("Vertical") * 10;
            h = Input.GetAxis("Horizontal") * 10;

            Vector3 move = trans.forward * v + trans.right * h;
            move.y = rb.linearVelocity.y;
            rb.linearVelocity = move;

            if (Input.GetKeyDown(KeyCode.Space) && canjump)
            {
                rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
                canjump = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isLocalPlayer)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                canjump = true;
            }
        }
    }

}
