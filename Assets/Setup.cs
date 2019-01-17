using UnityEngine;
using UnityEngine.Networking;

public class Setup : NetworkBehaviour
{

    public Behaviour[] components;
    public GameObject cam;
    public AudioListener listener;
    public Camera mainCam;

    public string remoteLayer;

    void Start()
    {
        
        if (!isLocalPlayer)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i].enabled = false;
                cam.SetActive(false);
                listener.enabled = false;
            }

            gameObject.layer = LayerMask.NameToLayer(remoteLayer);
        }
        else
        {
            mainCam = Camera.main;
            if (mainCam != null)
            {
                Camera.main.gameObject.SetActive(false);
            }
        }

        GetComponent<Player>().Init();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        GameManager.AddPlayer(GetComponent<NetworkIdentity>().netId.ToString(), GetComponent<Player>());
    }

    void Update()
    {

    }

    void OnDisable()
    {
        if (mainCam != null)
        {
            mainCam.gameObject.SetActive(true);
        }
        GameManager.RemovePlayer(GetComponent<NetworkIdentity>().netId.ToString());
    }
}


