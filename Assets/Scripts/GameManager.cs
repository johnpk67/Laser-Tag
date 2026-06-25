using Mirror;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    private bool P1;
    private bool P2;
    private bool lockintro;
    private GameObject Panel1;
    private GameObject Panel2;

    [SyncVar] public bool player1Selected;
    [SyncVar] public bool player2Selected;

    public GameObject BlueGeo;
    public GameObject RedGeo;

    public GameObject camcanvas;
    public GameObject ScorePanel;

    private bool amP1;
    private bool amP2;

    [SyncVar] public int SelectedChar;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectedChar = 0;
        if(isLocalPlayer){
            Panel1 = transform.Find("CamCanvas/Intro1").gameObject;
            Panel2 = transform.Find("CamCanvas/Intro2").gameObject;

            camcanvas.SetActive(true);
            Panel1.SetActive(true);
            P1 = true;
            P2 = false;
            lockintro = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
            if (P2 && Input.GetKeyDown(KeyCode.E) && !lockintro)
            {
                P2 = false;
                lockintro = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            PanelControl();
        }

        BlueGeo.SetActive(SelectedChar == 1);
        RedGeo.SetActive(SelectedChar == 2);
    }

    private void PanelControl()
    {
        if (!P1 && Panel1.activeSelf)
        {
            Panel1.SetActive(false);
            P1 = false;
        }
        if(!P1 && !P2 && !lockintro)
        {
            Panel2.SetActive(true);
            P2 = true;
        }
        if (!P2 && Panel2.activeSelf)
        {
            Panel2.SetActive(false);
            if (amP1)
            {
                BlueGeo.SetActive(true);
            }
            if (amP2)
            {
                RedGeo.SetActive(true);
            }
        }
    }

    public void ClickP1()
    {
        amP1 = true;
        P1 = false;
        ConfP1();
    }
    public void ClickP2()
    {
        amP2 = true;
        P1 = false;
        ConfP2();
    }
    
    [Command]
    public void ConfP1()
    {
        player1Selected = true;
        gameObject.tag = "BluePlayer";
        SelectedChar = 1;
        transform.position = new Vector3(0,3,-22);
    }
    [Command]
    public void ConfP2()
    {
        player2Selected = true;
        gameObject.tag = "RedPlayer";
        SelectedChar = 2;
        transform.position = new Vector3(0,3,22);
    }


}
