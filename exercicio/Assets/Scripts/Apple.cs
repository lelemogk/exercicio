using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor.SearchService;

public class Apple : MonoBehaviourPun
{
    const int speed = 5;
    [SerializeField] int score; // ????

    Rigidbody2D rigidbody2D;

    Vector2 screenBounds;

    public int Score { get => score;}

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        photonView.RPC("Destroy", RpcTarget.All);
    }

    [PunRPC]
    void Destroy()
    {
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddScore(score);
        }
    }
}
