using UnityEngine;
using Mirror;

public class MouseMove : NetworkBehaviour
{
    private float mousex;
    private float mousey;
    private float yrot;
    private float xrot;
    public Transform character;
    public Transform cam;
    private bool setsettings;
    public bool player1Selected;
    public bool player2Selected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setsettings = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!player1Selected && !player2Selected)
        {
            player1Selected = GetComponent<GameManager>().player1Selected;
            player2Selected = GetComponent<GameManager>().player2Selected;
        }
        if((player1Selected || player2Selected) && !setsettings)
        {
            if (isLocalPlayer)
            {
                cam.gameObject.SetActive(true);
            }
            if (!isLocalPlayer)
            {
                cam.gameObject.SetActive(false);
            }
            setsettings = true;
        }
        if (isLocalPlayer)
        {
            mousex = Input.GetAxis("Mouse X") * 10;
            mousey = Input.GetAxis("Mouse Y") * 10;

            yrot += mousex;
            xrot -= mousey;
            xrot = Mathf.Clamp(xrot, -30f, 30f);

            cam.position = character.position + Vector3.up * 1.7f;
            cam.rotation = Quaternion.Euler(xrot, yrot, 0);
            
        }
    }
}
