using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{

    bool alive = true;
    bool leavestate;

	public float speed = 5;

    float horizontalInput;
	private Animator anim;

    [SerializeField] Rigidbody rb;
    [SerializeField] float horizontalMultiplier = 2;

    // Aumento de velocidade associado ao aumento da pontuação
    public float speedIncreasePerPoint = 0.25f;

    [SerializeField] float jumpForce = 400f;
	[SerializeField] LayerMask groundMask;

	

    // Update is called once per frame

    private void FixedUpdate ()
    {
        if(!alive) return;

    	Vector3 forwardMove =transform.forward * speed * Time.fixedDeltaTime;
    	Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
    	rb.MovePosition(rb.position + forwardMove + horizontalMove);
    	
    	anim = GetComponent<Animator>();
    	
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");


        // Para o player pular sobre os obstáculos
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            anim.SetInteger("transition", 1);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetInteger("transition", 0);
        }

        // Se player cair do chão
        if(transform.position.y < -5){
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        //Restart the game
        Invoke("Restart", 1.5f); //Chamar função Restart depois de 2 segundos
    }

    void Restart(){
        //Delay entre atingir um ponto de morte e reiniciar o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        //Check whether we are currently grounded
        float height    = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2) + 0.01f, groundMask);

        // If we are, jump
        rb.AddForce(Vector3.up * jumpForce);
    }
    
}
