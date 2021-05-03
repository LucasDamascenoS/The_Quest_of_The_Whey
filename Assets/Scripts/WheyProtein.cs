using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheyProtein : MonoBehaviour
{

    // To make the whey protein's bowl spin
    [SerializeField] float turnSpeed = 90f; // vai rodar 90 graus a cada segundo

    private void OnTriggerEnter (Collider other)
    {

        // Para prevenir que wheys sejam criados em cima, ou nomesmo lugar que os obstáculos
        if (other.gameObject.GetComponent<Obstacle>() != null){
            Destroy(gameObject);
            return;
        }

        //Check if the object we collided with is the player
        if (other.gameObject.name != "Running"){ //checar se o object que colidimos não é o Player
            return;
        }

        // Add to the player's score
        GameManager.inst.IncrementScore();

        // Destroy this whey protein object
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Girar o whey, no eixo z, 90 graus a cada segundo
        // Time.deltaTime é a quantidade de tempo passada entre o frame passado e o atual
        // Em formato cilíndrico, rotaciona-se no eixo y, caso seja no formato de moeda, rotaciona-se no eixo z
        transform.Rotate(0, turnSpeed*Time.deltaTime, 0);    
    }
}
