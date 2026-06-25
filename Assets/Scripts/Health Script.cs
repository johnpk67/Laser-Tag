using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : NetworkBehaviour
{
    public Image Green;
    float fullhealth;
    [SyncVar] public float currenthealth;
    public GameObject LoosePanel;
    public GameObject WinPanel;
    public static bool death;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenthealth = 100;
        death = false;
        fullhealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
            Green.fillAmount = currenthealth / fullhealth;
            if(currenthealth <= 0)
            {
                LoosePanel.SetActive(true);
            }
            if(death && !LoosePanel.activeSelf)
            {
                WinPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider collider){
        if (collider.gameObject.CompareTag("Blast"))
        {
            currenthealth -= 10;
            if (!isLocalPlayer && currenthealth <= 0){ 
                death = true;
            }
        }
    }
}
