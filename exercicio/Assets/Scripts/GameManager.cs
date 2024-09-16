using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 1, Screen.height + 1));
    }
    #endregion


    TextMeshProUGUI scoreText;
    Vector2 screenBounds;
    int score;
    int playersInGame = 0;

    public Vector2 ScreenBounds { get => screenBounds; }
    public int Score { get => score; set => score = value; }

    const string playerPrefabPath = "Prefabs/Player";
    

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        photonView.RPC("AddPlayer", RpcTarget.AllBuffered);
    }

    private void CreatePlayer()
    {
        /*Player player = */NetworkManager.instance.Instantiate(playerPrefabPath, new Vector3(-5, 0), Quaternion.identity); //.GetComponent<Player>();
        /*player.*/photonView.RPC("Initialize", RpcTarget.All);
    }

    [PunRPC]
    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
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
