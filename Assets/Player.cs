using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour
{
    public int health = 100;

    [SyncVar]
    public int currentHealth;

    [SyncVar]
    private bool isDead;
    public bool IsDead
    {
        get { return isDead; }
        protected set { isDead = value; }
    }

    [SerializeField]
    private Behaviour[] disabed;
    private bool[] wasEnabled;

   public  void Init()
    {
        currentHealth = health;
        isDead = false;

        wasEnabled = new bool[disabed.Length];
        for (int i = 0; i < wasEnabled.Length; i++)
        {
            wasEnabled[i] = disabed[i].enabled;
        }
    }

    public void SetBaseData()
    {
        currentHealth = health;
        isDead = false;

        for (int i = 0; i < disabed.Length; i++)
        {
            disabed[i].enabled = wasEnabled[i];
        }

        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = true;
        }
    }

    void Update()
    {

    }

    [ClientRpc]
    public void RPCAddDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        isDead = true;
        Debug.Log("Dead");
        for (int i = 0; i < disabed.Length; i++)
        {
            disabed[i].enabled = false;
        }

        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }


        
    }
}
