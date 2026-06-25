using UnityEngine;
using Mirror;

public class AnimationScript : NetworkBehaviour
{
    Animator ani;
    private bool canjump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>();
        canjump = GetComponent<Move>().canjump;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            canjump = GetComponent<Move>().canjump;
            ani.SetBool("ToLand", canjump);
            ani.SetBool("ToJump", !canjump);
            ani.SetFloat("YVel", Input.GetAxis("Vertical"));
        }
    }
}
