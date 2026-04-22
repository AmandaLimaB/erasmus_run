using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{

    public AudioClip somMoeda;
    public TextMeshProUGUI textoUI;
    private int pontosTotal = 0;

    void Start()
    {
        AtualizarTexto();
    }

    public void AdicionarPonto()
    {

        // Toca o som na posição da câmera (para o som ser nítido)
        if (somMoeda != null)
        {
            AudioSource.PlayClipAtPoint(somMoeda, Camera.main.transform.position);
        }


        pontosTotal++;
        AtualizarTexto();
        
        // SALVAMENTO: Toda vez que ganha ponto, verificamos o recorde
        int recordeAtual = PlayerPrefs.GetInt("Recorde", 0);
        
        if (pontosTotal > recordeAtual)
        {
            PlayerPrefs.SetInt("Recorde", pontosTotal);
            PlayerPrefs.Save(); // Garante que salvou no disco
        }
        
        // Opcional: Salvar a pontuação da última partida para mostrar no Game Over
        PlayerPrefs.SetInt("PontuacaoFinal", pontosTotal);
    }

    void AtualizarTexto()
    {
        textoUI.text = "Pontos: " + pontosTotal.ToString();
    }
}