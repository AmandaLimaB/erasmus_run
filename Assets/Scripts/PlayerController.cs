using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    public GameManager gameManager;

    void Update()
    {
        // Pega o input do teclado (A/D ou setas)
        float x = Input.GetAxis("Horizontal");

        // Move o jogador para os lados
        transform.Translate(x * velocidade * Time.deltaTime, 0, 0);
    }

    
    void OnCollisionEnter(Collision collision)
    {
        // Se batermos em algo chamado "Obstaculo"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Morreu!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Use OnTriggerEnter se o item for um "fantasma" ou OnCollisionEnter se for sólido
    void OnTriggerEnter(Collider outro)
{
    if (outro.CompareTag("Pickup"))
    {
        // Desativamos o colisor do item IMEDIATAMENTE para ele não ser pego de novo
        outro.enabled = false; 

        FindObjectOfType<Pontuacao>().AdicionarPonto();
        Destroy(outro.gameObject); // :)
    }
}

}