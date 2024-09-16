using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviourPunCallbacks
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
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 2, Screen.height + 2));
    }
    #endregion
    Vector2 screenBounds;
    int score;
    int playersInGame = 0;
    Apple apple;

    public Vector2 ScreenBounds { get => screenBounds; }
    public int Score { get => score; set => score = value; }

    const string playerPrefabPath = "Prefabs/basket";
    

    private void Start()
    {
        photonView.RPC("AddPlayer", RpcTarget.AllBuffered);
    }

    private void CreatePlayer()
    {
        PlayerController player = NetworkManager.instance.Instantiate(playerPrefabPath, new Vector3(-2, -4), Quaternion.identity).GetComponent<PlayerController>();
        player.photonView.RPC("Initialize", RpcTarget.All);
    }

    public void AddScore(int score)
    {
        photonView.RPC("AddScoreRPC", RpcTarget.All, score);
    }
    [PunRPC]
    public void AddScoreRPC(int scorer)
    {
        score += scorer;
        UIManager.instance.UpdateScoreText(score);
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
