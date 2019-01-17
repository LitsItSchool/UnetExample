using UnityEngine;
using UnityEngine.Networking;

public class Shooting : NetworkBehaviour
{
    public PlayerBullet bullet;

    public Camera cam;

    public LayerMask mask;

    void Start()
    {
        if (cam == null)
        {
            Debug.Log("Camera null");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    [Client]
    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, bullet.range, mask))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.tag == "Player")
            {
                CmdPlayerDamage(hit.collider.name, bullet.damage);
            }
        }
    }

    [Command]
    void CmdPlayerDamage(string id, float damage)
    {
        var player = GameManager.GetPlayer(id);
        player.RPCAddDamage((int)damage);
    }
}
