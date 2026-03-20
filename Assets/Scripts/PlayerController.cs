using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    public GameManager gameManager;
    
    private Animator anim; // NOVO: Variável para guardar o componente de animação

    void Start()
    {
        // NOVO: Procuramos o Animator no modelo 3D que está dentro (filho) do Player
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        // Movimento lateral
        transform.Translate(x * velocidade * Time.deltaTime, 0, 0);

        // NOVO: Se o animator existir, avisamos que ele deve estar correndo
        // Geralmente, se o seu Animator só tem uma animação (Running), ela toca sozinha.
        // Mas se houver parâmetros, você os usaria aqui.
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Morreu!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Pickup"))
        {
            outro.enabled = false; 
            FindObjectOfType<Pontuacao>().AdicionarPonto();
            Destroy(outro.gameObject);
        }
    }
}