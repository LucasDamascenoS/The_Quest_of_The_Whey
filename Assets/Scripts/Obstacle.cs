using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    Player playerMoviment;
    // Start is called before the first frame update
    void Start()
    {
        playerMoviment = GameObject.FindObjectOfType<Player>();        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Running"){
            // Kill the player
            playerMoviment.Die();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
