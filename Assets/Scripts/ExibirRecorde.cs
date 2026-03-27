using UnityEngine;
using TMPro;

public class ExibirRecorde : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacaoFinal;
    public TextMeshProUGUI textoMelhorPontuacao;

    void Start()
    {
        // Pegamos os valores salvos pelo PlayerPrefs
        int final = PlayerPrefs.GetInt("PontuacaoFinal", 0);
        int melhor = PlayerPrefs.GetInt("Recorde", 0);

        // Exibimos nos textos da tela
        textoPontuacaoFinal.text = "Sua Pontuação: " + final.ToString();
        textoMelhorPontuacao.text = "Melhor Pontuação: " + melhor.ToString();
    }
}