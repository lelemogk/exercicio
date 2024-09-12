using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviourPun
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    #endregion



    Vector2 screenBounds;
    int score;


    const string playerPrefabPath = "Prefabs/Player";
    int playersInGame = 0;

    public Vector2 ScreenBounds { get => screenBounds; }
    public int Score { get => score; set => score = value; }

    private void Start()
    {
        photonView.RPC("AddPlayer", RpcTarget.AllBuffered);
    }

    private void CreatePlayer()
    {
        // Player player = NetworkManager.instance.Instantiate(playerPrefabPath, new Vector3(-5, 0), Quaternion.identity).GetComponent<Player>();
       // player.photonView.RPC("Initialize", RpcTarget.All);
    }

    [PunRPC]
    private void AddPlayer()
    {
        playersInGame++;
        if (playersInGame == PhotonNetwork.PlayerList.Length)
        {
            CreatePlayer();
        }
    }


}
