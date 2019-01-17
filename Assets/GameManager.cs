using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public static Dictionary<string,Player> gamePlayers = new Dictionary<string, Player>();


    public static void AddPlayer(string id, Player player)
    {
        player.transform.name = id;
        gamePlayers.Add(id, player);
    }

    public static void RemovePlayer(string id)
    {
        gamePlayers.Remove(id);
    }


    public static Player GetPlayer(string id)
    {
        return gamePlayers[id];
    }


    void Start()
    {
    }

    void Update()
    {

    }
}
