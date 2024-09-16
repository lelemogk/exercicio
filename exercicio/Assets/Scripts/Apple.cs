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
        
    }

    Vector2 GeneratePosition(GameObject apple)
    {
        Vector2 spriteBounds = apple.GetComponent<SpriteRenderer>().bounds.size / 2;

        Vector2 bounds = new Vector2(screenBounds.x - spriteBounds.x, screenBounds.y + spriteBounds.y);

        return new Vector2(Random.Range(-bounds.x, bounds.x), bounds.y);
    }

    [PunRPC]
    void Destroy()
    {

    }
}
