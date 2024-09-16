using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material material;
    const float speed = 0.07f;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
