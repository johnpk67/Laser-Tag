using Mirror;
using UnityEngine;

public class BlasterScript : NetworkBehaviour
{
    public GameObject projectile;
    public Transform cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire(cam.position, cam.forward);
            }
        }
    }

    [Command]
    private void Fire(Vector3 pos, Vector3 dir)
    {
        GameObject proj = Instantiate(projectile, pos + 3 * dir, Quaternion.identity);
        Rigidbody projRb = proj.GetComponent<Rigidbody>();
        projRb.linearVelocity = dir * 30f;
        NetworkServer.Spawn(proj);
    }
}
