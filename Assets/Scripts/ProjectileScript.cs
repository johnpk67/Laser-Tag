using UnityEngine;
using Mirror;

public class ProjectileScript : MonoBehaviour
{
    private float timer;
    public GameObject BluePS;
    public GameObject RedPS;
    public GameObject YellowPS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("BluePlayer"))
        {
            GameObject ps = Instantiate(BluePS, transform.position, Quaternion.identity);
            NetworkServer.Spawn(ps);
            Debug.Log("BluePlayer");
        }
        else if (collider.CompareTag("RedPlayer"))
        {
            GameObject ps = Instantiate(RedPS, transform.position, Quaternion.identity);
            NetworkServer.Spawn(ps);
            Debug.Log("RedPlayer");
        }
        else
        {
            GameObject ps = Instantiate(YellowPS, transform.position, Quaternion.identity);
            NetworkServer.Spawn(ps);
        }
        Destroy(gameObject);
    }
}
