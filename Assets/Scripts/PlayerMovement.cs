using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;

	public float speed = 5;
	[SerializeField] Rigidbody rb;
	[SerializeField] float horizontalMultiplier = 2;

	float horizontalInput;

    // Update is called once per frame

    private void FixedUpdate ()
    {
        if(!alive) return;

    	Vector3 forwardMove =transform.forward * speed * Time.fixedDeltaTime;
    	Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
    	rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Se player cair do chão
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
}
