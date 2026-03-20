using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    private int pontosTotal = 0; // Usamos int para números inteiros (1, 2, 3...)

    void Start()
    {
        AtualizarTexto();
    }

    // Esta função será chamada pelo Player ao coletar algo
    public void AdicionarPonto()
    {
        pontosTotal++;
        AtualizarTexto();
    }

    void AtualizarTexto()
    {
        textoUI.text = "Pontos: " + pontosTotal.ToString();
    }
}