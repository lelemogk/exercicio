using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    string[] apples = {"Prefabs/Red Apple", "Prefabs/Green Apple", "Prefabs/Golden Apple"};

    float timer;

    const int cooldown = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        
    }

    void Spawn()
    {
        if (NetworkManager.instance.masterClient)
        {
            timer -= Time.deltaTime;

            string appleSelected;

            if (timer <= 0)
            {
                float appleIndex = Random.Range(0f, 1f);


                if (appleIndex < 0.5f)
                {
                    appleSelected = apples[0];
                }
                else if (appleIndex < 0.8f && appleIndex > 0.5f)
                {
                    appleSelected = apples[1];
                }
                else
                {
                    appleSelected = apples[2];
                }

                NetworkManager.instance.Instantiate(appleSelected, new Vector2(Random.Range(-10, 10), GameManager.instance.ScreenBounds.y), Quaternion.identity);


                timer = cooldown;
            }
        }
    }
}
