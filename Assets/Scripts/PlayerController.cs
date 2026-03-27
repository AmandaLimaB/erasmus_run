using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    public GameManager gameManager; // Nota: Veja se você ainda está usando esse GameManager, se não, pode remover.
    
    private Animator anim; // Variável para guardar o componente de animação

    void Start()
    {
        // Procuramos o Animator no modelo 3D que está dentro (filho) do Player
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        // Movimento lateral
        transform.Translate(x * velocidade * Time.deltaTime, 0, 0);

        // Se o animator existir, avisamos que ele deve estar correndo
        if (anim != null) 
        {
            // Aqui você ativaria os parâmetros da animação se necessário
        }
    }

    // --- AQUI ESTÁ A MUDANÇA PRINCIPAL ---
    void OnCollisionEnter(Collision collision)
    {
        // Verificamos se colidimos com algo que tenha a Tag "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {   
            // Se o jogador não pegou nada, salvamos 0 como pontuação final da rodada
            if(PlayerPrefs.GetInt("PontuacaoFinal") != 0) {
                // (Opcional) apenas para garantir que o valor resete para a nova partida
            }
            SceneManager.LoadScene("GameOver");
            Debug.Log("Morreu! Indo para Game Over.");
            
            // LINHA ANTERIOR (Que reiniciava a fase):
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // NOVA LINHA (Que chama a cena de GameOver):
            // O nome entre aspas deve ser EXATAMENTE igual ao nome da cena que você criou.
            SceneManager.LoadScene("GameOver"); 
        }
    }

    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Pickup"))
        {
            // Para garantir que o pickup seja destruído e o script Pontuacao funcione
            if (FindObjectOfType<Pontuacao>() != null)
            {
                FindObjectOfType<Pontuacao>().AdicionarPonto();
            }
            Destroy(outro.gameObject);
        }
    }
}